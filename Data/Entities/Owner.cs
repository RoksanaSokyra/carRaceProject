using System;
using System.Collections.Generic;
using System.Text;

namespace RaceSimulator.Data.Entities
{
    public class Owner
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Driver> Drivers { get; set; }
        public virtual ICollection<Car> Cars { get; set; }
        public Owner(string name) { Name = name; }
    }
}
