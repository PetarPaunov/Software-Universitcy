using Gym.Models.Equipment.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gym.Repositories.Contracts
{
    public class EquipmentRepository : IRepository<IEquipment>
    {
        private readonly List<IEquipment> equipment;
        public EquipmentRepository()
        {
            this.equipment = new List<IEquipment>();
        }
        public IReadOnlyCollection<IEquipment> Models
            => this.equipment;

        public void Add(IEquipment model)
        {
            this.equipment.Add(model);
        }
        //TODO: Chel FindByType for potentioal bug;
        public IEquipment FindByType(string type)
            => this.equipment.FirstOrDefault(x => x.GetType().Name == type);

        public bool Remove(IEquipment model)
            => this.equipment.Remove(model);
    }
}
