using System;
using System.Buffers;
using System.Collections.Generic;
using System.Text;

namespace RaceSimulator.Data.Entities
{//struktura folderow cz ok - entities w data cz po prostu samo
    public class Car
    {
        public int Id { get; set; } //czy wszystko powinno miec settery np. id, weight, horsepower, maneuverability
        public int OwnerID { get; set; }
        public virtual Owner Owner { get; set; }
        public string Name { get; set; }
        public double WeightInKg { get; set; }
        public int HorsePower { get; set; }
        public double ManeuverabilityLevel { get; set; }

        public Car(string name, double weightInKg, int horsePower, double maneuverabilityLevel)
        {
            Name = name;
            WeightInKg = weightInKg;
            HorsePower = horsePower;
            ManeuverabilityLevel = maneuverabilityLevel;
        }

    }
}
