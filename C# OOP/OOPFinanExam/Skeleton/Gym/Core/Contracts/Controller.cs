using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms.Contracts;
using Gym.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gym.Core.Contracts
{
    public class Controller : IController
    {
        private IRepository<IEquipment> equipment;
        private ICollection<IGym> gyms;

        public Controller()
        {
            this.equipment = new EquipmentRepository();
            this.gyms = new List<IGym>();

        }
        
        public string AddAthlete(string gymName, string athleteType, string athleteName, string motivation, int numberOfMedals)
        {
            IAthlete athlete = null;

            IGym gym = this.gyms.FirstOrDefault(x => x.Name == gymName);

            if (athleteType == "Boxer")
            {
                athlete = new Boxer(athleteName, motivation, numberOfMedals);
            }
            else if (athleteType == "Weightlifter")
            {
                athlete = new Weightlifter(athleteName, motivation, numberOfMedals);
            }
            else
            {
                throw new InvalidOperationException("Invalid athlete type.");
            }

            if (athlete.GetType() == typeof(Boxer) && gym.GetType() == typeof(WeightliftingGym))
            {
                return "The gym is not appropriate.";
            }
            else if (athlete.GetType() == typeof(Weightlifter) && gym.GetType() == typeof(BoxingGym))
            {
                return "The gym is not appropriate.";
            }
            else
            {
                gym.AddAthlete(athlete);
                return $"Successfully added {athleteType} to {gymName}.";
            }

        }

        public string AddEquipment(string equipmentType)
        {
            IEquipment equipment = null;

            if (equipmentType == "BoxingGloves")
            {
                equipment = new BoxingGloves();
            }
            else if (equipmentType == "Kettlebell")
            {
                equipment = new Kettlebell();
            }
            else
            {
                throw new InvalidOperationException("Invalid equipment type.");
            }

            this.equipment.Add(equipment);
            return $"Successfully added {equipmentType}.";
        }

        public string AddGym(string gymType, string gymName)
        {
            IGym gym = null;

            if (gymType == "BoxingGym")
            {
                gym = new BoxingGym(gymName);
            }
            else if (gymType == "WeightliftingGym")
            {
                gym = new WeightliftingGym(gymName);
            }
            else
            {
                throw new InvalidOperationException("Invalid gym type.");
            }

            this.gyms.Add(gym);

            return $"Successfully added {gymType}.";
        }

        public string EquipmentWeight(string gymName)
        {
            //TODE:CHEK HERE
            IGym gym = this.gyms.FirstOrDefault(x => x.Name == gymName);

            var totalWheight = gym.EquipmentWeight;

            return $"The total weight of the equipment in the gym {gymName} is {totalWheight:F2} grams.";
        }

        public string InsertEquipment(string gymName, string equipmentType)
        {
            IEquipment equipment = this.equipment.FindByType(equipmentType);

            if (equipment == null)
            {
                throw new InvalidOperationException($"There isn’t equipment of type {equipmentType}.");
            }
            IGym gym = this.gyms.FirstOrDefault(x => x.Name == gymName);

            gym.AddEquipment(equipment);
            this.equipment.Remove(equipment);

            return $"Successfully added {equipmentType} to {gymName}.";
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var gym in this.gyms)
            {
                sb.AppendLine(gym.GymInfo());
            }

            return sb.ToString().TrimEnd();
        }

        public string TrainAthletes(string gymName)
        {
            //TODE:Check here 
            IGym gym = this.gyms.FirstOrDefault(x => x.Name == gymName);
            foreach (var athlet in gym.Athletes)
            {
                athlet.Exercise();
            }

            return $"Exercise athletes: {gym.Athletes.Count}.";
        }
    }
}
