using RaceSimulator.Data.Entities;
using RaceSimulator.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace RaceSimulator
{
    class ConsoleApplication
    {
        private IDriverService _driverService;
        private ICarService _carService;
        private IOwnerService _ownerService;
        public ConsoleApplication(IDriverService driverService, ICarService carService, IOwnerService ownerService)
        {
            _driverService = driverService;
            _carService = carService;
            _ownerService = ownerService;
        }
        public void Run()
        {
            int mainOption;
            int subOption;
            do
            {
                mainOption = MainMenuOptions(); //czy read?
                switch (mainOption)
                {
                    case 1:
                        subOption = CreateMenuOptions();
                        switch (subOption)
                        {
                            case 1:
                                CreateOwner();
                                break;
                            case 2:
                                CreateDriver();
                                break;
                            case 3:
                                CreateCar();
                                break;
                        }
                        break;
                    case 2:
                        subOption = ReadMenuOptions();
                        switch (subOption)
                        {
                            case 1:
                                ReadOwner();
                                break;
                            case 2:
                                ReadDriver();
                                break;
                            case 3:
                                ReadCar();
                                break;
                        }
                        break;
                    case 3:
                        subOption = UpdateMenuOptions();
                        switch (subOption)
                        {
                            case 1:
                                UpdateOwner();
                                break;
                            case 2:
                                UpdateDriver();
                                break;
                            case 3:
                                UpdateCar();
                                break;
                        }
                        break;
                    case 4:
                        subOption = DeleteMenuOptions();
                        switch (subOption)
                        {
                            case 1:
                                DeleteOwner();
                                break;
                            case 2:
                                DeleteDriver();
                                break;
                            case 3:
                                DeleteCar();
                                break;
                        }
                        break;
                }
            } while (mainOption != 5);
            Environment.Exit(0);
        }
        private int MainMenuOptions()
        {
            Console.WriteLine("1 - Create");
            Console.WriteLine("2 - Read");
            Console.WriteLine("3 - Update");
            Console.WriteLine("4 - Remove");
            Console.WriteLine("5 - Quit");
            int option = Convert.ToInt32(Console.ReadLine());
            return option;
        }
        private int CreateMenuOptions()
        {
            Console.WriteLine("1 - Create Owner");
            Console.WriteLine("2 - Create Driver");
            Console.WriteLine("3 - Create Car");
            int option = Convert.ToInt32(Console.ReadLine());
            return option;
        }
        private  int ReadMenuOptions()
        {
            Console.WriteLine("1 - Read Owner");
            Console.WriteLine("2 - Read Driver");
            Console.WriteLine("3 - Read Car");
            int option = Convert.ToInt32(Console.ReadLine());
            return option;
        }

        private int UpdateMenuOptions()
        {
            Console.WriteLine("1 - Update Owner");
            Console.WriteLine("2 - Update Driver");
            Console.WriteLine("3 - Update Car");
            int option = Convert.ToInt32(Console.ReadLine());
            return option;
        }
        private int DeleteMenuOptions()
        {
            Console.WriteLine("1 - Delete Owner");
            Console.WriteLine("2 - Delete Driver");
            Console.WriteLine("3 - Delete Car");
            int option = Convert.ToInt32(Console.ReadLine());
            return option;
        }

        private void CreateOwner()
        {
            Console.WriteLine("Please provide owner name");
            string ownerName = Console.ReadLine();
            while (string.IsNullOrEmpty(ownerName))
            {
                Console.WriteLine("Not a valid value. Try again");
                ownerName = Console.ReadLine();
            }
            Owner owner = new Owner(ownerName);
            owner.Cars = new List<Car>(); // czy to w tym miejscu tworzymy liste
            owner.Drivers = new List<Driver>();
            _ownerService.CreateOwner(owner);
            
        }
        private void CreateCar()
        {
            string result;
            int ownerId, horsePower;
            string name;
            double weight, manuverability;
            var owners = _ownerService.GetOwners();
            foreach(Owner owner in owners)
            {
                Console.WriteLine($"Name: {owner.Name} ID: {owner.Id}");
            }
            Console.WriteLine("Please provide owner id");
            result = Console.ReadLine();
            while(!Int32.TryParse(result, out ownerId))
            {
                Console.WriteLine("Not a valid value. Try again");
                result = Console.ReadLine();
            }

            Console.WriteLine("Please provide name");
            name = Console.ReadLine();
            while(string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Not a valid value. Try again");
                name = Console.ReadLine();
            }

            Console.WriteLine("Please provide weight");
            result = Console.ReadLine();
            while (!Double.TryParse(result, out weight))
            {
                Console.WriteLine("Not a valid value. Try again");
                result = Console.ReadLine();
            }

            Console.WriteLine("Please provide horse power");
            result = Console.ReadLine();
            while (!Int32.TryParse(result, out horsePower))
            {
                Console.WriteLine("Not a valid value. Try again");
                result = Console.ReadLine();
            }

            Console.WriteLine("Please provide manuverability");
            result = Console.ReadLine();
            while (!Double.TryParse(result, out manuverability))
            {
                Console.WriteLine("Not a valid value. Try again");
                result = Console.ReadLine();
            }

            Car car = new Car(name, weight, horsePower, manuverability) { OwnerID = ownerId }; //przypisujemy id czy obiekt?
            _carService.CreateCar(car);
        }

        private void CreateDriver()
        {
            string result;
            int age, ownerId;
            string name;
            double skillLevel, staminaLevel;

            var owners = _ownerService.GetOwners();
            foreach (Owner owner in owners)
            {
                Console.WriteLine($"Name: {owner.Name} ID: {owner.Id}");
            }
            Console.WriteLine("Please provide owner id");
            result = Console.ReadLine();
            while (!Int32.TryParse(result, out ownerId))
            {
                Console.WriteLine("Not a valid value. Try again");
                result = Console.ReadLine();
            }
            Console.WriteLine("Please provide name");
            name = Console.ReadLine();
            while (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Not a valid value. Try again");
                name = Console.ReadLine();
            }
            Console.WriteLine("Please provide age");
            result = Console.ReadLine();
            while (!Int32.TryParse(result, out age))
            {
                Console.WriteLine("Not a valid value. Try again");
                result = Console.ReadLine();
            }

            Console.WriteLine("Please provide skill level");
            result = Console.ReadLine();
            while (!Double.TryParse(result, out skillLevel))
            {
                Console.WriteLine("Not a valid value. Try again");
                result = Console.ReadLine();
            }

            Console.WriteLine("Please provide stamina level");
            result = Console.ReadLine();
            while (!Double.TryParse(result, out staminaLevel))
            {
                Console.WriteLine("Not a valid value. Try again");
                result = Console.ReadLine();
            }

            Driver driver = new Driver(name, age, skillLevel, staminaLevel) { OwnerId = ownerId };
            _driverService.CreateDriver(driver);
        }

        private void ReadOwner()
        {
            string result;
            int id;
            Console.WriteLine("Please provide owner id");
            result = Console.ReadLine();
            if(string.IsNullOrEmpty(result))
            {
                var owners = _ownerService.GetOwners();
                foreach (Owner owner in owners)
                {
                    DisplayOwnerInfo(owner);
                }
            }
            else if (Int32.TryParse(result, out id))
            {
                var owner = _ownerService.GetOwner(id);
                DisplayOwnerInfo(owner);

            }
            else Console.WriteLine("Not a valid value. Try again");
        }
        private void DisplayOwnerInfo(Owner owner)
        {
            Console.WriteLine($"Id: {owner.Id}");
            Console.WriteLine($"Name: {owner.Name}");
            foreach(Car car in owner.Cars)
            {
                DisplayCarInfo(car);
            }
            foreach(Driver driver in owner.Drivers)
            {
                DisplayDriverInfo(driver);
            }
        }

        private void ReadCar()
        {
            string result;
            int id;
            Console.WriteLine("Please provide car id");
            result = Console.ReadLine();
            if (string.IsNullOrEmpty(result))
            {
                var cars = _carService.GetCars();
                foreach (Car car in cars)
                {
                    DisplayCarInfo(car);
                }
            }
            else if (Int32.TryParse(result, out id))
            {
                var car = _carService.GetCar(id);
                DisplayCarInfo(car);

            }
            else Console.WriteLine("Not a valid value. Try again");
        }
        private void DisplayCarInfo(Car car)
        {
            Console.WriteLine($"Id: {car.Id}");
            Console.WriteLine($"OwnerID: {car.OwnerID}");
            Console.WriteLine($"Name: {car.Name}");
            Console.WriteLine($"Weight in kg: {car.WeightInKg}");
            Console.WriteLine($"Horse power: {car.HorsePower}");
            Console.WriteLine($"Maneuverability level: {car.ManeuverabilityLevel}");
        }
        private void ReadDriver()
        {
            string result;
            int id;
            Console.WriteLine("Please provide driver id");
            result = Console.ReadLine();
            if (string.IsNullOrEmpty(result))
            {
                var drivers = _driverService.GetDrivers();
                foreach (Driver driver in drivers)
                {
                    DisplayDriverInfo(driver);
                }
            }
            else if (Int32.TryParse(result, out id))
            {
                var driver = _driverService.GetDriver(id);
                DisplayDriverInfo(driver);

            }
            else Console.WriteLine("Not a valid value. Try again");
        }
        private void DisplayDriverInfo(Driver driver)
        {
            Console.WriteLine($"Id: {driver.Id}");
            Console.WriteLine($"OwnerID: {driver.OwnerId}");
            Console.WriteLine($"Name: {driver.Name}");
            Console.WriteLine($"Age: {driver.Age}");
            Console.WriteLine($"Skill level: {driver.SkillLevel}");
            Console.WriteLine($"Stamina level: {driver.StaminaLevel}");
        }
        private void UpdateOwner()
        {
            Console.WriteLine("Please provide owner name");
            string ownerName = Console.ReadLine();
            while (string.IsNullOrEmpty(ownerName))
            {
                Console.WriteLine("Not a valid value. Try again");
                ownerName = Console.ReadLine();
            }
            Owner owner = new Owner(ownerName);
            _ownerService.UpdateOwner(owner);
        }
        private void UpdateCar()
        {
            string result;
            int carId, horsePower;
            string name;
            double weight, manuverability;
            Console.WriteLine("Please provide car id");
            result = Console.ReadLine();
            while (!Int32.TryParse(result, out carId))
            {
                Console.WriteLine("Not a valid value. Try again");
                result = Console.ReadLine();
            }

            Console.WriteLine("Please provide name");
            name = Console.ReadLine();
            while (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Not a valid value. Try again");
                name = Console.ReadLine();
            }

            Console.WriteLine("Please provide weight");
            result = Console.ReadLine();
            while (!Double.TryParse(result, out weight))
            {
                Console.WriteLine("Not a valid value. Try again");
                result = Console.ReadLine();
            }

            Console.WriteLine("Please provide horse power");
            result = Console.ReadLine();
            while (!Int32.TryParse(result, out horsePower))
            {
                Console.WriteLine("Not a valid value. Try again");
                result = Console.ReadLine();
            }

            Console.WriteLine("Please provide manuverability");
            result = Console.ReadLine();
            while (!Double.TryParse(result, out manuverability))
            {
                Console.WriteLine("Not a valid value. Try again");
                result = Console.ReadLine();
            }

            Car car = new Car(name, weight, horsePower, manuverability) { Id = carId }; //przypisujemy id czy obiekt?
            _carService.UpdateCar(car);
        }
        private void UpdateDriver()
        {
            string result;
            int driverId, age;
            string name;
            double skillLevel, staminaLevel;
            Console.WriteLine("Please provide driver id");
            result = Console.ReadLine();
            while (!Int32.TryParse(result, out driverId))
            {
                Console.WriteLine("Not a valid value. Try again");
                result = Console.ReadLine();
            }
            Console.WriteLine("Please provide name");
            name = Console.ReadLine();
            while (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Not a valid value. Try again");
                name = Console.ReadLine();
            }
            Console.WriteLine("Please provide age");
            result = Console.ReadLine();
            while (!Int32.TryParse(result, out age))
            {
                Console.WriteLine("Not a valid value. Try again");
                result = Console.ReadLine();
            }

            Console.WriteLine("Please provide skill level");
            result = Console.ReadLine();
            while (!Double.TryParse(result, out skillLevel))
            {
                Console.WriteLine("Not a valid value. Try again");
                result = Console.ReadLine();
            }

            Console.WriteLine("Please provide stamina level");
            result = Console.ReadLine();
            while (!Double.TryParse(result, out staminaLevel))
            {
                Console.WriteLine("Not a valid value. Try again");
                result = Console.ReadLine();
            }

            Driver driver = new Driver(name, age, skillLevel, staminaLevel) { Id = driverId };
            _driverService.UpdateDriver(driver);
        }
        private void DeleteOwner()
        {
            var owners = _ownerService.GetOwners();
            foreach (Owner owner in owners)
            {
                Console.WriteLine($"Name: {owner.Name} ID: {owner.Id}");
            }
            Console.WriteLine("Please provide owner id");
            int id = Convert.ToInt32(Console.ReadLine());
            _ownerService.DeleteOwner(id);
        }
        private void DeleteDriver()
        {
            var drivers = _driverService.GetDrivers();
            foreach (Driver driver in drivers)
            {
                Console.WriteLine($"Name: {driver.Name} ID: {driver.Id}");
            }
            Console.WriteLine("Please provide driver id");
            int id = Convert.ToInt32(Console.ReadLine());
            _driverService.DeleteDriver(id);
        }
        private void DeleteCar()
        {
            var cars = _carService.GetCars();
            foreach (Car car in cars)
            {
                Console.WriteLine($"Name: {car.Name} ID: {car.Id}");
            }
            Console.WriteLine("Please provide car id");
            int id = Convert.ToInt32(Console.ReadLine());
            _carService.DeleteCar(id);
        }

    }
}
