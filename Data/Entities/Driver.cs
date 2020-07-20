using System;
using System.Buffers;
using System.Collections.Generic;
using System.Text;

namespace RaceSimulator.Data.Entities
{
    public class Driver
    {
        public int Id { get; set; }
        public int OwnerId { get; set; }
        public virtual Owner Owner { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public double SkillLevel { get; set; }
        public double StaminaLevel { get; set; }
        public Driver(string name, int age, double skillLevel, double staminaLevel)
        {
            Name = name;
            Age = age;
            SkillLevel = skillLevel;
            StaminaLevel = staminaLevel;
        }
    }
}
