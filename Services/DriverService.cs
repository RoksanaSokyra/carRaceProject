using Microsoft.EntityFrameworkCore;
using RaceSimulator.Data;
using RaceSimulator.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RaceSimulator.Services
{
    public interface IDriverService
    {
        void CreateDriver(int ownerId, string name, int age, double skillLevel, double staminaLevel);
        void ReadDriverInfo(int id);
        void DeleteDriver(int id);
    }
    class DriverService : IDriverService
    {
        private readonly AppDbContext _context; //jako pole czy wlasciwosc

        public DriverService(AppDbContext context)
        {
            _context = context;
        }

        public void CreateDriver(int ownerId, string name, int age, double skillLevel, double staminaLevel)
        {
            var owner = _context.Owners.Include(owner => owner.Drivers).SingleOrDefault(x => x.Id == ownerId);
            Driver driver = new Driver(name, age, skillLevel, staminaLevel);
            owner.Drivers.Add(driver);
            _context.SaveChanges();
        }

        public void ReadDriverInfo(int id)
        {
            var driver = _context.Drivers.SingleOrDefault(x => x.Id == id);
            if (driver == null)
            {
                throw new Exception("Driver not found");
            }
            Console.WriteLine($"Id: {driver.Id}");
            Console.WriteLine($"OwnerID: {driver.OwnerId}");
            Console.WriteLine($"Name: {driver.Name}");
            Console.WriteLine($"Age: {driver.Age}");
            Console.WriteLine($"Skill level: {driver.SkillLevel}");
            Console.WriteLine($"Stamina level: {driver.StaminaLevel}");
        }

        public void DeleteDriver(int id)
        {
            var driver = _context.Drivers.Find(id);
            if (driver != null)
            {
                _context.Drivers.Remove(driver);
                _context.SaveChanges();
            }
        }
    }
}
