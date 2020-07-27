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
        int CreateDriver(Driver driver);
        Driver GetDriver(int id);
        ICollection<Driver> GetDrivers();
        Driver UpdateDriver(Driver driver);
        void DeleteDriver(int id);
    }
    class DriverService : IDriverService
    {
        private readonly AppDbContext _context; //jako pole czy wlasciwosc

        public DriverService(AppDbContext context)
        {
            _context = context;
        }

        public int CreateDriver(Driver driver)
        {
            var owner = _context.Owners.Include(owner => owner.Drivers).SingleOrDefault(x => x.Id == driver.OwnerId);
            if (owner == null)
            {
                throw new Exception("Owner not found");
            }
            owner.Drivers.Add(driver); 
            _context.SaveChanges();
            return driver.Id;
        }

        public Driver GetDriver(int id)
        {
            var driver = _context.Drivers.SingleOrDefault(driver => driver.Id == id);
            if (driver == null)
            {
                throw new Exception("Driver not found");
            }
            return driver;
        }
        public ICollection<Driver> GetDrivers() //czy spr czy drivers null, czy empty czy nic
        {
            return _context.Drivers.ToList<Driver>();
        }

        public Driver UpdateDriver(Driver driverParam)
        {
            var driver = _context.Drivers.SingleOrDefault(driver => driver.Id == driverParam.Id);
            driver.Name = driverParam.Name;
            driver.Age = driverParam.Age;
            driver.SkillLevel = driverParam.SkillLevel;
            driver.StaminaLevel = driverParam.StaminaLevel;
            if (driver == null)
                throw new Exception("Driver not found");

            _context.Drivers.Update(driver);
            _context.SaveChanges();
            return driver;
        }
        public void DeleteDriver(int id)
        {
            var driver = _context.Drivers.SingleOrDefault(driver => driver.Id == id); //przetestowac. czy powinien byc include?
            if (driver == null)
            {
                throw new Exception("Driver not found");
            }
            _context.Drivers.Remove(driver);
            _context.SaveChanges();
        }
    }
}
