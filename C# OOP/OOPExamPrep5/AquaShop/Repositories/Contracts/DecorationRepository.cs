using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AquaShop.Models.Decorations.Contracts;

namespace AquaShop.Repositories.Contracts
{
    public class DecorationRepository : IRepository<IDecoration>
    {
        private readonly List<IDecoration> decorations;
        public DecorationRepository()
        {
            this.decorations = new List<IDecoration>();
        }
        public IReadOnlyCollection<IDecoration> Models
            => this.decorations.AsReadOnly();

        public void Add(IDecoration model)
            => this.decorations.Add(model);

        public IDecoration FindByType(string type)
        {
            IDecoration decoration = this.decorations.FirstOrDefault(X => X.GetType().Name == type);
            return decoration;
        }

        public bool Remove(IDecoration model)
            => this.decorations.Remove(model);
    }
}
