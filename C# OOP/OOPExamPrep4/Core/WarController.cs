using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Items;

namespace WarCroft.Core
{
	public class WarController
	{
		private List<Character> party;
		private List<Item> itemPool;
		public WarController()
		{
			this.party = new List<Character>();
			this.itemPool = new List<Item>();
		}

		public string JoinParty(string[] args)
		{
			string characterType = args[0];
			string name = args[1];
			Character character = null;
			if (characterType == "Priest")
            {
				character = new Priest(name);
            }
            else if (characterType == "Warrior")
            {
				character = new Warrior(name);
            }
            else
            {
				throw new ArgumentException($"Invalid character type {characterType}!");
			}

			this.party.Add(character);

			return $"{name} joined the party!";
		}

		public string AddItemToPool(string[] args)
		{
			Item item = null;
			string itemName = args[0];
            if (itemName == "FirePotion")
			{
				item = new FirePotion();
            }
            else if (itemName == "HealthPotion")
            {
				item = new HealthPotion();
            }
            else
            {
				throw new ArgumentException($"Invalid item {itemName}!");
			}

			this.itemPool.Add(item);
			return $"{itemName} added to pool.";
		}

		public string PickUpItem(string[] args)
		{
			string name = args[0];
			Character character = this.party.FirstOrDefault(x => x.Name == name);

            if (character == null)
            {
				throw new ArgumentException($"Character {name} not found!");	
			}

            if (this.itemPool.Count == 0)
            {
				throw new InvalidOperationException("No items left in pool!");
			}
			Item item = this.itemPool.Last();
			character.Bag.AddItem(item);

			return $"{character.Name} picked up {item.GetType().Name}!";
		}

		public string UseItem(string[] args)
		{
			string characterName = args[0];
			string itemName = args[1];

			Character character = this.party.FirstOrDefault(x => x.Name == characterName);

            if (character == null)
            {
				throw new ArgumentException($"Character {characterName} not found!");
			}
			Item item = this.itemPool.FirstOrDefault(x => x.GetType().Name == itemName);

            if (item == null)
            {
				throw new InvalidOperationException("Bag is empty!");
            }
			character.UseItem(item);

			return $"{character.Name} used {itemName}.";
		}

		public string GetStats()
		{
			StringBuilder stringBuilder = new StringBuilder();
			List<Character> characters = this.party.OrderByDescending(x => x.IsAlive).ThenBy(x => x.Health).ToList();

            foreach (var character in characters)
            {
				string deadOrAlive = "";
                if (character.IsAlive)
                {
					deadOrAlive = "Alive";
				}
                else
                {
					deadOrAlive = "Dead";

				}
				stringBuilder.AppendLine($"{character.Name} - HP: {character.Health}/{character.BaseHealth}, AP: {character.Armor}/{character.BaseArmor}, Status: {deadOrAlive}");
            }

			return stringBuilder.ToString().TrimEnd();
		}

		public string Attack(string[] args)
		{
			StringBuilder sb = new StringBuilder();
			string attackerName = args[0];
			string receiverName = args[1];

			Warrior attacker = this.party.FirstOrDefault(x => x.Name == attackerName) as Warrior;
			Character reciver = this.party.FirstOrDefault(x => x.Name == receiverName);

            if (attacker == null)
            {
				throw new ArgumentException($"Character {attackerName} not found!");
			}
            if (reciver == null)
            {
				throw new ArgumentException($"Character {receiverName} not found!");
			}
            if (!reciver.IsAlive)
            {
				throw new ArgumentException($"{attacker.Name} cannot attack!");
            }

			attacker.Attack(reciver);
			sb.AppendLine($"{attackerName} attacks {receiverName} for {attacker.AbilityPoints} hit points! {receiverName} has {reciver.Health}/{reciver.BaseHealth} HP and {reciver.Armor}/{reciver.BaseArmor} AP left!");
            if (!reciver.IsAlive)
            {
				sb.AppendLine($"{reciver.Name} is dead!");

			}

			return sb.ToString().TrimEnd();
		}

		public string Heal(string[] args)
		{
			string healerName = args[0];
			string healingReceiverName = args[1];

			Character healer = this.party.FirstOrDefault(x => x.Name == healerName);
			Character healReciver = this.party.FirstOrDefault(x => x.Name == healingReceiverName);

            if (healer == null)
            {
				throw new ArgumentException($"Character {healer} not found!");
            }
            if (healReciver == null)
            {
				throw new ArgumentException($"Character {healReciver} not found!");
            }

            if (!healReciver.IsAlive)
            {
				throw new ArgumentException($"{healerName} cannot heal!");

			}
			
			healReciver.Health += healer.AbilityPoints;
			return $"{healer.Name} heals {healReciver.Name} for {healer.AbilityPoints}! {healReciver.Name} has {healReciver.Health} health now!";
		}
	}
}
