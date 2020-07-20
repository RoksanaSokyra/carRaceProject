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
            string ownerName = Console.ReadLine().ToString();
            _ownerService.CreateOwner(ownerName);
        }
        private void CreateCar()
        {
            Console.WriteLine("Please provide owner id");
            int ownerId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please provide name");
            string name = Console.ReadLine().ToString();
            Console.WriteLine("Please provide weight");
            double weight = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Please provide horse power");
            int horsePower = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please provide manuverability");
            double manuverability = Convert.ToDouble(Console.ReadLine());
            _carService.CreateCar(ownerId, name, weight, horsePower, manuverability);
        }

        private void CreateDriver()
        {
            Console.WriteLine("Please provide owner id");
            int ownerId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please provide name");
            string name = Console.ReadLine().ToString();
            Console.WriteLine("Please provide age");
            int age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please provide skill level");
            double skillLevel = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Please provide stamina level");
            double staminaLevel = Convert.ToDouble(Console.ReadLine());
            _driverService.CreateDriver(ownerId, name, age, skillLevel, staminaLevel);
        }

        private void ReadOwner()
        {
            Console.WriteLine("Please provide owner id");
            int id = Convert.ToInt32(Console.ReadLine());
            _ownerService.ReadOwnersInfo(id);
        }
        private void ReadCar()
        {
            Console.WriteLine("Please provide car id");
            int id = Convert.ToInt32(Console.ReadLine());
            _carService.ReadCarInfo(id);
        }
        private void ReadDriver()
        {
            Console.WriteLine("Please provide driver id");
            int id = Convert.ToInt32(Console.ReadLine());
            _driverService.ReadDriverInfo(id);
        }
        private void DeleteOwner()
        {
            Console.WriteLine("Please provide owner id");
            int id = Convert.ToInt32(Console.ReadLine());
            _ownerService.DeleteOwner(id);
        }
        private void DeleteDriver()
        {
            Console.WriteLine("Please provide driver id");
            int id = Convert.ToInt32(Console.ReadLine());
            _driverService.DeleteDriver(id);
        }
        private void DeleteCar()
        {
            Console.WriteLine("Please provide car id");
            int id = Convert.ToInt32(Console.ReadLine());
            _carService.DeleteCar(id);
        }

    }
}
