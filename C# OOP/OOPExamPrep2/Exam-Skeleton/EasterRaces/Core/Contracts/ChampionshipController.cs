using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Cars.Entities;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Repositories.Contracts;
using EasterRaces.Repositories.Entities;
using System;
using System.Linq;
using System.Text;

namespace EasterRaces.Core.Contracts
{
    public class ChampionshipController : IChampionshipController
    {
        private IRepository<IDriver> driverRepositiry;
        private IRepository<ICar> carRepository;
        private IRepository<IRace> RaceRepository;

        public ChampionshipController()
        {
            this.driverRepositiry = new DriverRepository();
            this.carRepository = new CarRepository();
            this.RaceRepository = new RaceRepository();
        }
        public string AddCarToDriver(string driverName, string carModel)
        {
            IDriver driver = this.driverRepositiry.GetByName(driverName);
            if (driver == null)
            {
                throw new InvalidOperationException($"Driver {driverName} could not be found.");
            }
            ICar car = this.carRepository.GetByName(carModel);
            if (car == null)
            {
                throw new InvalidOperationException($"Car {carModel} could not be found.");
            }

            driver.AddCar(car);

            return $"Driver {driverName} received car {carModel}.";
        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            IRace race = this.RaceRepository.GetByName(raceName);
            IDriver driver = this.driverRepositiry.GetByName(driverName);
            if (race == null)
            {
                throw new InvalidOperationException($"Race {raceName} could not be found.");
            }
            if (driver == null)
            {
                throw new InvalidOperationException($"Driver {driverName} could not be found.");
            }

            race.AddDriver(driver);

            return $"Driver {driverName} added in {raceName} race.";
        }

        public string CreateCar(string type, string model, int horsePower)
        {

            if (this.carRepository.GetByName(model) != null)
            {
                throw new ArgumentException($"Car {model} is already created.");
            }

            ICar car = null;
            if (type == "Muscle")
            {
                car = new MuscleCar(model, horsePower);
            }
            if (type == "Sports")
            {
                car = new SportsCar(model, horsePower);
            }

            this.carRepository.Add(car);

            return $"{car.GetType().Name} {model} is created.";
        }

        public string CreateDriver(string driverName)
        {
            
            var exist = this.driverRepositiry.GetByName(driverName);
            if (exist != null)
            {
                throw new ArgumentException($"Driver {driverName} is already created.");
            }

            IDriver driver = new Driver(driverName);
            this.driverRepositiry.Add(driver);
            return $"Driver {driverName} is created.";
        }

        public string CreateRace(string name, int laps)
        {
            if (this.RaceRepository.GetByName(name) != null)
            {
                throw new InvalidOperationException($"Race {name} is already create.");
            }

            IRace race = new Race(name, laps);

            this.RaceRepository.Add(race);

            return $"Race {name} is created.";
        }

        public string StartRace(string raceName)
        {
            IRace race = this.RaceRepository.GetByName(raceName);

            if (race == null)
            {
                throw new InvalidOperationException($"Race {raceName} could not be found.");
            }

            if (race.Drivers.Count < 3)
            {
                throw new InvalidOperationException($"Race {raceName} cannot start with less than 3 participants.");
            }

            var sortedPlayer = race.Drivers.OrderByDescending(d => d.Car.CalculateRacePoints(race.Laps)).ToList();

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Driver {sortedPlayer[0].Name} wins {raceName} race.");
            sb.AppendLine($"Driver {sortedPlayer[1].Name} is second in {raceName} race.");
            sb.AppendLine($"Driver {sortedPlayer[2].Name} is third in {raceName} race.");

            this.RaceRepository.Remove(race);
            return sb.ToString().TrimEnd();

        }
    }
}
