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
    { //czy to powinny byc voidy
        //czy dawac wszystkie parametry czy gotowy obiekt jak np w car create
        void CreateCar(int ownerId, string name, double weight, int horsePower, double manuverability);
        void ReadCarInfo(int id);
        void UpdateCar(Car carParam);
        void DeleteCar(int id);
    }
    class CarService : ICarService
    {
        private readonly AppDbContext _context; //jako pole czy wlasciwosc

        public CarService(AppDbContext context)
        {
           _context = context;
        }

        public void CreateCar(int ownerId, string name, double weight, int horsePower, double manuverability)
        {
            var owner = _context.Owners.Include(owner => owner.Cars).SingleOrDefault(x => x.Id == ownerId);
            Car car = new Car(name, weight, horsePower, manuverability);
            owner.Cars.Add(car);
            _context.SaveChanges();
        }

        public void UpdateCar(Car carParam)
        { //jak madrzej zrobic update
            var car = _context.Cars.Find(carParam.Id);

            if (car == null)
                throw new Exception("Car not found");

            if (!string.IsNullOrWhiteSpace(car.Name))
                car.Name = car.Name;
            if (carParam.WeightInKg != car.WeightInKg && carParam.WeightInKg > 0)
                car.WeightInKg = carParam.WeightInKg;
            if (carParam.HorsePower != car.HorsePower && carParam.HorsePower > 0)
                car.HorsePower = carParam.HorsePower;
            if (carParam.ManeuverabilityLevel != carParam.ManeuverabilityLevel && carParam.ManeuverabilityLevel > 0)
                car.ManeuverabilityLevel = carParam.ManeuverabilityLevel;
            //sprawdzenie ownera - czy parametr po parametrze tu spr czy odeslanie do metody ownerservice czy tylko ref

        }
            public void ReadCarInfo(int id)
        {
            var car = _context.Cars.SingleOrDefault(x => x.Id == id);
            if (car == null)
            {
                throw new Exception("Car not found");
            }
            Console.WriteLine($"Id: {car.Id}");
            Console.WriteLine($"OwnerID: {car.OwnerID}");
            Console.WriteLine($"Name: {car.Name}");
            Console.WriteLine($"Weight in kg: {car.WeightInKg}");
            Console.WriteLine($"Horse power: {car.HorsePower}");
            Console.WriteLine($"Maneuverability level: {car.ManeuverabilityLevel}");
        }

        public void DeleteCar(int id)
        {
            var car = _context.Cars.Find(id);
            if (car != null)
            {
                _context.Cars.Remove(car);
                _context.SaveChanges();
            }
        }
    }
}
