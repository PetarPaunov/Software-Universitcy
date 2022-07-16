using System.Collections.Generic;

namespace CarDealer.DTO
{
    public class CarsModel
    {
        public string Make { get; set; }

        public string Model { get; set; }

        public int travelledDistance { get; set; }

        public IEnumerable<int> partsId { get; set; }
    }
}
