using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Decorations.Contracts
{
    public abstract class Decoration : IDecoration
    {
        private int comfort;
        private decimal price;

        protected Decoration(int comfort, decimal price)
        {
            Comfort = comfort;
            Price = price;
        }

        public int Comfort 
        { 
            get => comfort; 
            private set
            {
                this.comfort = value;
            }
        }

        public decimal Price 
        { 
            get => price; 
            private set
            {
                this.price = value;
            } 
        }
    }
}
