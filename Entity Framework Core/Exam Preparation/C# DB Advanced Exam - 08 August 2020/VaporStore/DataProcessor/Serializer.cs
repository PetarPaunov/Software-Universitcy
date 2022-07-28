namespace VaporStore.DataProcessor
{
	using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Xml;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using VaporStore.DataProcessor.Dto.Export;

    public static class Serializer
	{
		public static string ExportGamesByGenres(VaporStoreDbContext context, string[] genreNames)
		{
			var gameByGenres = context.Genres.ToList()
				.Where(x => genreNames.Contains(x.Name))
				.Select(x => new
				{
					Id = x.Id,
					Genre = x.Name,
					Games = x.Games.Select(g => new
					{
						Id = g.Id,
						Title = g.Name,
						Developer = g.Developer.Name,
						Tags = string.Join(", ", g.GameTags.Select(gt => gt.Tag.Name)),
						Players = g.Purchases.Count()
					})
					.Where(x => x.Players > 0)
					.OrderByDescending(x => x.Players)
					.ThenBy(x => x.Id),
					TotalPlayers = x.Games.Sum(x => x.Purchases.Count())
				})
				.OrderByDescending(x => x.TotalPlayers)
				.ThenBy(x => x.Id);


			var result = JsonConvert.SerializeObject(gameByGenres, Newtonsoft.Json.Formatting.Indented);

			return result.ToString();
		}

		public static string ExportUserPurchasesByType(VaporStoreDbContext context, string storeType)
		{
			var users = context.Users
				.ToList()
				.Where(x => x.Cards.Any(x => x.Purchases.Any(p => p.Type.ToString() == storeType)))
				.Select(x => new ExportUsersModel
				{
					Username = x.Username,
					Purchases = x.Cards.SelectMany(c => c.Purchases)
					    .Where(p => p.Type.ToString() == storeType)
						.Select(p => new PurchesesExportModel
						{
							Card = p.Card.Number,
							Cvs = p.Card.Cvc,
							Date = p.Date.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
							Game = new GameExportModel
							{
								Title = p.Game.Name,
								Genre = p.Game.Genre.Name,
								Price = p.Game.Price
							}
						})
						.OrderBy(x => x.Date)
						.ToArray(),
					TotalSpent = x.Cards
					.Sum(p => p.Purchases.Where(p => p.Type.ToString() == storeType)
					.Sum(p => p.Game.Price))
				})
				.OrderByDescending(x => x.TotalSpent)
				.ThenBy(x => x.Username)
				.ToArray();

			var xmlSerializer = new XmlSerializer(typeof(ExportUsersModel[]), new XmlRootAttribute("Users"));

			var stringWriter = new StringWriter();
			var ns = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
			xmlSerializer.Serialize(stringWriter, users, ns);

			return stringWriter.ToString();
		}
	}
}