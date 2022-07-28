namespace VaporStore.DataProcessor
{
	using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using VaporStore.Data.Models;
    using VaporStore.Data.Models.Enums;
    using VaporStore.DataProcessor.Dto.Import;

    public static class Deserializer
	{
		public static string ImportGames(VaporStoreDbContext context, string jsonString)
		{
			var games = JsonConvert.DeserializeObject<GamesImportModel[]>(jsonString);

			var sb = new StringBuilder();

            foreach (var game in games)
            {
                if (!IsValid(game) || !game.Tags.Any())
                {
					sb.AppendLine("Invalid Data");
					continue;
                }

				var gameRealiceDate = DateTime
					.ParseExact(game.ReleaseDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);

				var gameGenre = context.Genres.FirstOrDefault(x => x.Name == game.Genre);

                if (gameGenre == null)
                {
					gameGenre = new Genre { Name = game.Genre };
                }

				var gameDeveloper = context.Developers.FirstOrDefault(x => x.Name == game.Developer);

                if (gameDeveloper == null)
                {
					gameDeveloper = new Developer { Name = game.Developer };
                }

				var currentGame = new Game
				{
					Name = game.Name,
					Price = game.Price,
					ReleaseDate = gameRealiceDate,
					Developer = gameDeveloper,
					Genre = gameGenre,
				};

                foreach (var gameTag in game.Tags)
                {
					var tag = context.Tags.FirstOrDefault(x => x.Name == gameTag)
						?? new Tag { Name = gameTag };

					currentGame.GameTags.Add(new GameTag { Tag = tag });
                }

				context.Games.Add(currentGame);
				context.SaveChanges();

				sb.AppendLine($"Added {game.Name} ({game.Genre}) with {game.Tags.Count()} tags");
            }

			return sb.ToString().TrimEnd();
		}

		public static string ImportUsers(VaporStoreDbContext context, string jsonString)
		{
			var users = JsonConvert.DeserializeObject<ImportUsersModel[]>(jsonString);

			var sb = new StringBuilder();

            foreach (var user in users)
            {
                if (!IsValid(user) || !user.Cards.All(IsValid))
                {
					sb.AppendLine("Invalid Data");
					continue;
                }

				var curentUser = new User
				{
					FullName = user.FullName,
					Username = user.Username,
					Email = user.Email,
					Age = user.Age,
					Cards = user.Cards.Select(x => new Card
					{
						Number = x.Number,
						Cvc = x.CVC,
						Type = x.Type
					})
					.ToArray()
				};

				context.Users.Add(curentUser);
				context.SaveChanges();

				sb.AppendLine($"Imported {user.Username} with {user.Cards.Count()} cards");
            }

			return sb.ToString().TrimEnd();
		}

		public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
		{
			var xmlSerializer = new XmlSerializer(typeof(ImportPurchesesModel[]), new XmlRootAttribute("Purchases"));
			var sb = new StringBuilder();

			var textReader = new StringReader(xmlString);

			var purchesesDto = xmlSerializer.Deserialize(textReader) as ImportPurchesesModel[];

            foreach (var purches in purchesesDto)
            {
                if (IsValid(purches))
                {
					sb.AppendLine("Invalid Data");
					continue;
				}

				var date = DateTime
					.TryParseExact
					(purches.Date, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out var currentDate);

                if (currentDate == null)
                {
					sb.AppendLine("Invalid Data");
					continue;
				}

				var currentPurches = new Purchase
				{
					Type = purches.Type,
					ProductKey = purches.Key,
					Date = currentDate,
				};

				currentPurches.Card = context.Cards.FirstOrDefault(x => x.Number == purches.Card);
				currentPurches.Game = context.Games.FirstOrDefault(x => x.Name == purches.Title);

				context.Purchases.Add(currentPurches);
				context.SaveChanges();

				var username = context.Users.FirstOrDefault(x => x.Cards.Any(c => c.Number == purches.Card));

				sb.AppendLine($"Imported {purches.Title} for {username.Username}");
            }

			return sb.ToString().TrimEnd();
		}

		private static bool IsValid(object dto)
		{
			var validationContext = new ValidationContext(dto);
			var validationResult = new List<ValidationResult>();

			return Validator.TryValidateObject(dto, validationContext, validationResult, true);
		}
	}
}