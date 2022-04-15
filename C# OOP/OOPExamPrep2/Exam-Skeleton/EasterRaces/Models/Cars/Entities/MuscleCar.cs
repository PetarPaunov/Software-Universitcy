using EasterRaces.Models.Cars.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Cars.Entities
{
    public class MuscleCar : Car
    {
        private const double MuscleCarCubicCentimeters = 5000;
        private const int MinHorsePower = 400;
        private const int MaxHorsePower = 600;

        private int muscleCarHoresPower;
        public MuscleCar(string model, int horsePower) 
            : base(model, horsePower, MuscleCarCubicCentimeters, MinHorsePower, MaxHorsePower)
        {
        }
 
    }
}
