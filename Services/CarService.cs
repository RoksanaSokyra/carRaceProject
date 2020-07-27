using Microsoft.EntityFrameworkCore;
using RaceSimulator.Data;
using RaceSimulator.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RaceSimulator.Services
{
    //czy interfejsy w tym sammy folderze 
    //czy takie podejscie jest ok - service czy cqrs
    public interface ICarService
    { 
        int CreateCar(Car car);
        Car GetCar(int id);
        ICollection<Car> GetCars();
        Car UpdateCar(Car carParam);
        void DeleteCar(int id);
    }
    class CarService : ICarService
    {
        private readonly AppDbContext _context; //jako pole czy wlasciwosc

        public CarService(AppDbContext context)
        {
           _context = context;
        }

        public int CreateCar(Car car)
        {
            var owner = _context.Owners.Include(owner => owner.Cars).SingleOrDefault(x => x.Id == car.OwnerID);
            if (owner == null)
            {
                throw new Exception("Owner not found");
            }
            owner.Cars.Add(car);
            _context.SaveChanges();
            return car.Id;
        }
        public Car GetCar(int id)
        {
            var car = _context.Cars.SingleOrDefault(x => x.Id == id);
            if (car == null)
            {
                throw new Exception("Car not found");
            }
            return car;
        }

        public ICollection<Car> GetCars()
        {
            return _context.Cars.ToList<Car>(); //czy trzeba includy? spr breakpointem 
        }

        public Car UpdateCar(Car carParam)
        {
            var car = _context.Cars.SingleOrDefault(car => car.Id == carParam.Id);
            car.Name = carParam.Name;
            car.WeightInKg = carParam.WeightInKg;
            car.HorsePower = carParam.HorsePower;
            car.ManeuverabilityLevel = car.ManeuverabilityLevel;
            if (car == null)
                throw new Exception("Car not found");

            _context.Cars.Update(car);
            _context.SaveChanges();
            return car;
        }

        public void DeleteCar(int id)
        {
            var car = _context.Cars.SingleOrDefault(car => car.Id == id);
            if (car != null)
            {
                _context.Cars.Remove(car);
                _context.SaveChanges();
            }
        }
    }
}
