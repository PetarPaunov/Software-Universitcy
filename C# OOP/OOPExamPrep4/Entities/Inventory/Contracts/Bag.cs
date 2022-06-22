using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Inventory.Contracts
{
    public abstract class Bag : IBag
    {
        private readonly List<Item> items;
        public Bag(int capacity)
        {
            this.Capacity = capacity;
            this.items = new List<Item>();
        }
        
            

        public int Load => Items.Sum(x => x.Weight);

        public IReadOnlyCollection<Item> Items
            => this.items;

        public int Capacity { get; set; } = 100;

        public void AddItem(Item item)
        {
            var curentLoad = this.Items.Sum(x => x.Weight);
            if (curentLoad + item.Weight > this.Capacity)
            {
                throw new InvalidOperationException("Bag is full!");
            }

            this.items.Add(item);
        }

        public Item GetItem(string name)
        {
            if (this.items.Count == 0)
            {
                throw new InvalidOperationException("Bag is empty!");
            }
            Item item = this.items.FirstOrDefault(x => x.GetType().Name == name);
            if (item == null)
            {
                throw new ArgumentException($"No item with name {name} in bag!");
            }
            this.items.Remove(item);
            return item;
        }
    }
}
