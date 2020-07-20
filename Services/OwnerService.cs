using Microsoft.EntityFrameworkCore;
using RaceSimulator.Data;
using RaceSimulator.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RaceSimulator.Services
{
    public interface IOwnerService
    {
        void CreateOwner(string name);
        void DeleteOwner(int id);
        void ReadOwnersInfo(int id);
    }
    class OwnerService : IOwnerService
    {
        private readonly AppDbContext _context; //jako pole czy wlasciwosc

        public OwnerService(AppDbContext context)
        {
            _context = context;
        }

        public void CreateOwner(string name)
        {
            Owner owner = new Owner(name);
            owner.Cars = new List<Car>();
            owner.Drivers = new List<Driver>();
            _context.Owners.Add(owner);
            _context.SaveChanges();
        }
        public void ReadOwnersInfo(int id)
        { //czy wywolywac metody service z pozostalych, jesli tak jak wywolywac service
            var owner = _context.Owners.Include(owner => owner.Cars).Include(owner => owner.Drivers).SingleOrDefault(x => x.Id == id);
            if (owner == null)
            {
                throw new Exception("Driver not found");
            }
            Console.WriteLine($"Id: {owner.Id}");
            Console.WriteLine($"Name: {owner.Name}");
            foreach (Car car in owner.Cars)
            {
                Console.WriteLine($"Id: {car.Id}");
                Console.WriteLine($"OwnerID: {car.OwnerID}");
                Console.WriteLine($"Name: {car.Name}");
                Console.WriteLine($"Weight in kg: {car.WeightInKg}");
                Console.WriteLine($"Horse power: {car.HorsePower}");
                Console.WriteLine($"Maneuverability level: {car.ManeuverabilityLevel}");
            }
            foreach (Driver driver in owner.Drivers)
            {
                Console.WriteLine($"Id: {driver.Id}");
                Console.WriteLine($"OwnerID: {driver.OwnerId}");
                Console.WriteLine($"Name: {driver.Name}");
                Console.WriteLine($"Age: {driver.Age}");
                Console.WriteLine($"Skill level: {driver.SkillLevel}");
                Console.WriteLine($"Stamina level: {driver.StaminaLevel}");
            }
        }
        public void DeleteOwner(int id)
        {
            var owner = _context.Owners.Find(id);
            if (owner != null)
            {
                _context.Owners.Remove(owner);
                _context.SaveChanges();
            }
        }
    }
}
