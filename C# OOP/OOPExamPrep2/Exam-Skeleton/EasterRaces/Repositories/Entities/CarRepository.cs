using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Repositories.Entities
{
    public class CarRepository : IRepository<ICar>
    {
        private List<ICar> Cars;
        public CarRepository()
        {
            this.Cars = new List<ICar>();
        }

        public void Add(ICar model)
          => this.Cars.Add(model);

        public IReadOnlyCollection<ICar> GetAll()
          => this.Cars.ToList();

        public ICar GetByName(string name)
          => this.Cars.FirstOrDefault(c => c.Model == name);

        public bool Remove(ICar model)
          => this.Cars.Remove(model);
    }
}
