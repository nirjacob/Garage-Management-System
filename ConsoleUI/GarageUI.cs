using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Ex03.GarageLogic;
using System.Reflection;


namespace Ex03.ConsoleUI
{
    class GarageUI
    {
        Garage m_Garage;
        public Garage GarageStorage
        {
            get
            {
                return m_Garage;
            }
        }
        public GarageUI()
        {
            m_Garage = new Garage();
        }
        public void run()
        {
            bool programRunning = true;
            eActionType action;
            while (programRunning)
            {
                printMenuOptions();
                action = readAction();
                takeAction(action);
            }
        }
        public eActionType readAction()
        {
            string input = Console.ReadLine();
            int action = -1;
            try
            {
                action = int.Parse(input);
            }
            catch (FormatException)
            {
                Console.WriteLine("Please enter a valid action (number between 1-9)");
                Thread.Sleep(1000);
            }
            return (eActionType)action;
        }
        public void takeAction(eActionType action)
        {
            switch  (action)
            {
                case eActionType.InsertNewCar:
                    InsertNewVehicle();
                    break;
                case eActionType.DisplayLicensePlates:
                    //
                    break;
                case eActionType.ChangeVehicleStatus:
                    //
                    break;
                case eActionType.InflateTireToMaximum:
                    //
                    InflateTiersToMaximum();
                    break;
                case eActionType.FuelVehicle:
                    //
                    //1,2,3,4
                    //switch c
                    break;
                case eActionType.ChargeElectric:
                    //
                    break;
                case eActionType.DisplayCarDetails:
                    //
                    break;
                default:
                    break;
            }
        }
        public void InflateTiersToMaximum()
        {
            string licensePlate = getLicensePlate();
            if(GarageStorage.AlreadyInGarage(licensePlate) == false)
            {
                GarageStorage.InflateToMax(licensePlate);
            }
            else
            {
                InflateTiersToMaximum();
            }
        }
        public void printMenuOptions()
        {
            Console.Clear();
            string mainMenu = string.Format(@" 

 -------------------------------------------
|1. Insert a vehicle to the garage.         |
|2. Display all vehicles license number.    |
|3. Change vehicle garage status.           |
|4. Inflate vehicle tiers.                  |
|5. Fuel vehicle to maximum.                |
|6. Charge vehicle to maximum.              |
|7. Display car details.                    |
 -------------------------------------------
");
            Console.WriteLine(mainMenu);
        }
        private string getLicensePlate()
        {
            Console.WriteLine("Please enter the license plate:");
            string licensePlate = Console.ReadLine();
            return licensePlate;
        }
        public void InsertNewVehicle()
        {
            string licensePlate = getLicensePlate();
            if (GarageStorage.AlreadyInGarage(licensePlate))
            {
                GarageStorage.setVehicleStatus(licensePlate, eVehicleStatus.InRepair);
            }
            Console.WriteLine("Please select vehicle type: ");
            List<string> supportedVehicles = GarageStorage.GetSupportedVehicles();

            int choiseIndex = 1;
            foreach (string supportedVehicle in supportedVehicles)
            {
                Console.WriteLine("{0}.{1}", choiseIndex, supportedVehicle);
                choiseIndex++;
            }
            string vehicleChoise = Console.ReadLine();
            //Check enum choice.
            Vehicle newVehicle = GarageStorage.VehicleCreator.CreateVehicle(vehicleChoise);
            getCarDetailes(newVehicle, licensePlate);

        }


        //Type t = obj.GetType(); // Where obj is object whose properties you need.
        //PropertyInfo [] pi = t.GetProperties();
        //foreach (PropertyInfo p in pi)
        //{
        //    System.Console.WriteLine(p.Name + " : " + p.GetValue(obj));
        //}

        //public void InsertNewVehicle()
        //{
        //    string licensePlate = getLicensePlate();

        //    if (GarageStorage.AlreadyInGarage(licensePlate))
        //    {
        //        GarageStorage.setVehicleStatus(licensePlate, eVehicleStatus.InRepair);
        //    }
        //    FillNewVehicleForm(licensePlate);
        //    AddVehicleToGarage();
        //}
        public void AddVehicleToGarage()
        {
            switch(GarageStorage.NewVehicleForm.VehicleType)
            {
                case eVehicleType.Car:
                    addCar();
                    break;
                case eVehicleType.Motorcycle:
                    addMotorcycle();
                    break;
                case eVehicleType.Truck:
                    addTruck();
                    break;

                default:
                    break;
            }
        }
        private void addCar()
        {
            string colorMsg = string.Format(@"
Please enter the door color:
1.Red
2.Silver
3.White
4.Black
");
                        string numOfDoorsMsg = string.Format(@"
Please enter the door color:
2, 3, 4 or 5
");
            //eVehicleColor vehicleColor = (eVehicleColor)getCarDetailes(colorMsg, 1, 4);
            //eNumberOfDoors numOfDoors = (eNumberOfDoors)getCarDetailes(numOfDoorsMsg, 2, 5);

            //GarageStorage.CreateNewCar(vehicleColor, numOfDoors);
        }
        private void addTruck()
        {
            bool hazardousMaterial = containsHazardousMaterials();
            float maxCarryingWeight = getmaxCarryingWeight();
            //GarageStorage.CreateNewTruck(hazardousMaterial, maxCarryingWeight);
        }
        private float getmaxCarryingWeight()
        {
            bool validInput = false;
            int maxCarryingWeight = 0;
            Console.WriteLine("Enter truck maximum carrying weight:");
            while (!validInput)
            {
                validInput = true;
                try
                {
                    maxCarryingWeight = int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input, please enter a number");
                    validInput = false;
                }

            }
            return maxCarryingWeight;

        }
        private bool containsHazardousMaterials()
        {
            string msg = string.Format(@"Does the truck carry any hazardous materials?
1.yes
2.no
");
            Console.WriteLine(msg);
            bool validInput = false;
            string userInput = string.Empty;
            int userChoise = 0;
            while (!validInput)
            {
                validInput = true;
                userInput = Console.ReadLine();
                try
                {
                    userChoise = int.Parse(userInput);
                    checkValidity(2, 1, userChoise);
                }
                catch (ValueOutOfRangeException)
                {
                    Console.WriteLine("Invalid number, please enter 1 or 2.");
                    validInput = false;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input, please enter 1 or 2");
                    validInput = false;
                }
            }
            if (userChoise == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void addMotorcycle()
        {
            eLicenseType licenseType = getLicenseType();
            int engineCapacity = getEngineCapacity();
            //GarageStorage.CreateNewMotorcycle(licenseType, engineCapacity);
        }
        private void getCarDetailes(Vehicle i_NewVehicle, string i_LicensePlate)
        {
            Type vehicleType = i_NewVehicle.GetType();
            FieldInfo[] fields = vehicleType.GetFields(BindingFlags.Instance| BindingFlags.NonPublic);
            foreach(FieldInfo field in fields)
            {
                string fieldName = getFieldName(field.Name);
                Console.WriteLine("Please enter {0} : ", fieldName);
                //Console.WriteLine("Please enter {0} : ", field.Name);

                Console.WriteLine(field.FieldType);
                if (field.FieldType == typeof(Single))
                {
                    float valueFromUser = readIntFromUser();
                    field.SetValue(i_NewVehicle, valueFromUser);
                }
                if (field.FieldType.BaseType == typeof(Customer))
                {
                    Customer valueFromUser = readCustomerFromUser();
                    field.SetValue(i_NewVehicle, valueFromUser);
                }
                if (field.FieldType.BaseType == typeof(Engine))
                {
                    Engine valueFromUser = readEngineFromUser();
                    field.SetValue(i_NewVehicle, valueFromUser);
                }
                if (field.FieldType.BaseType == (typeof(List<Wheel>)))
                {
                    List<Wheel> valueFromUser = readWheelsFromUser();
                    field.SetValue(i_NewVehicle, valueFromUser);
                }
                if (field.FieldType.BaseType == typeof(Int32))
                {
                    int valueFromUser = readIntFromUser();
                    field.SetValue(i_NewVehicle, valueFromUser);
                }
                else if (field.FieldType.IsEnum)
                {
                    int valueFromUser = readEnumFromUser();
                    field.SetValue(i_NewVehicle, valueFromUser);
                }
                else if (field.FieldType == typeof(String))
                {
                    string valueFromUser = readStringFromUser();
                    field.SetValue(i_NewVehicle, valueFromUser);
                }
            }
        }
        private string getFieldName(string i_FieldName)
        {
            string finalFieldName = i_FieldName;
            bool foundUppercase = false;
            finalFieldName = finalFieldName.Replace("m_", "");
            for (int i = 1; i < finalFieldName.Length; i++)
            {
                if (Char.IsUpper(finalFieldName[i])&&foundUppercase==false)
                {
                    foundUppercase = true;
                    finalFieldName = finalFieldName.Insert(i," ");
                }
                else
                {
                    foundUppercase = false;
                }
            }
            finalFieldName = finalFieldName.ToLower();
            return finalFieldName;
        }
        private Engine readEngineFromUser()
        {

        }
        private Customer readCustomerFromUser()
        {
            
        }
        private float readIntFromUser()
        {
            float inputFromUser = float.Parse(Console.ReadLine());
            return inputFromUser;
        }
        private int getEngineCapacity()
        {
            Console.WriteLine("Please enter the engine capacity: ");
            bool validInput = false;
            string engineCapacity = string.Empty;
            int engineCapacityValue = 0;
            while (!validInput)
            {
                validInput = true;
                engineCapacity = Console.ReadLine();
                try
                {
                    engineCapacityValue = int.Parse(engineCapacity);

                }
                catch  (FormatException)
                {
                    Console.WriteLine("Invalid input, please enter the full number of engine capacity.");
                    validInput = false;
                }
            }
            return engineCapacityValue;
        }
        private eLicenseType getLicenseType()
        {
            string msg = string.Format(@"Please choose license type:
1.A
2.B1
3.AA
4.BB
");
            Console.WriteLine(msg);
            int motorcycleLicense = 0;
            bool validInput = false;
            while (!validInput)
            {
                validInput = true;
                try
                {
                    motorcycleLicense = int.Parse(Console.ReadLine());
                    checkValidity(1, 4, motorcycleLicense);
                }
                catch (ValueOutOfRangeException valueError)
                {
                    Console.WriteLine(valueError.Message);
                    validInput = false;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input, please enter a number");
                    validInput = false;
                }

            }
            return (eLicenseType)motorcycleLicense;

        }


        private void FillNewVehicleForm(string i_LicensePlate)
        {

            GarageStorage.NewVehicleForm.LicensePlate = i_LicensePlate;
            GarageStorage.NewVehicleForm.ModelName = getModelNameFromUser();
            GarageStorage.NewVehicleForm.VehicleType = getVehicleTypeFromUser();
            if (GarageStorage.NewVehicleForm.VehicleType == eVehicleType.Truck)
            {
                GarageStorage.NewVehicleForm.EnergyType = eEnergyType.Fuel;
            }
            else
            {
                GarageStorage.NewVehicleForm.EnergyType = setEnergyTypeFromUser();
            }
            GarageStorage.NewVehicleForm.EnergyLeft = getEnergyLeftFromUser();
            GarageStorage.NewVehicleForm.MaxWheelAirPressure = getMaxWheelAirPressure();
            GarageStorage.NewVehicleForm.WheelsAirPressure = getWheelsAirPressure();
            GarageStorage.NewVehicleForm.OwnerName = getOwnerName();
            GarageStorage.NewVehicleForm.OwnerPhone = getPhone();
            GarageStorage.NewVehicleForm.MaxEnergy = getMaxEnergy();
            GarageStorage.NewVehicleForm.FuelType = getFuelType();
            GarageStorage.NewVehicleForm.NumOfWheels = getNumOfWheels();
            GarageStorage.NewVehicleForm.WheelManufacturer = getWheelManufacturer();
        }
        private string getWheelManufacturer()
        {
            Console.WriteLine("Please enter the vehicle model name: ");
            return Console.ReadLine();
        }
        private int getMaxWheelAirPressure()
        {
            if (GarageStorage.NewVehicleForm.VehicleType == eVehicleType.Car)
            {
                return 32;
            }
            else if (GarageStorage.NewVehicleForm.VehicleType == eVehicleType.Motorcycle)
            {
                return 30;
            }
            else //GarageStorage.NewVehicleForm.VehicleType == eVehicleType.Truck
            {
                return 26;
            }
        }
        private int getNumOfWheels()
        {
            if (GarageStorage.NewVehicleForm.VehicleType == eVehicleType.Car)
            {
                return 4;
            }
            else if (GarageStorage.NewVehicleForm.VehicleType == eVehicleType.Motorcycle)
            {
                return 2;
            }
            else //GarageStorage.NewVehicleForm.VehicleType == eVehicleType.Truck
            {
                return 16;
            }
        }
        private eFuelType getFuelType()
        {

            if (GarageStorage.NewVehicleForm.VehicleType == eVehicleType.Car)
            {
                return eFuelType.Octan95;
            }
            else if (GarageStorage.NewVehicleForm.VehicleType == eVehicleType.Motorcycle)
            {
                return eFuelType.Octan98;
            }
            else //GarageStorage.NewVehicleForm.VehicleType == eVehicleType.Truck
            {
                return eFuelType.Soler;
            }
        }
        private float getMaxEnergy()
        {
            if(GarageStorage.NewVehicleForm.VehicleType == eVehicleType.Car)
            {
                if(GarageStorage.NewVehicleForm.EnergyType == eEnergyType.Electricity)
                {
                    return 3.2f;
                }
                else if (GarageStorage.NewVehicleForm.EnergyType == eEnergyType.Fuel)
                {
                    return 45f;
                }
            }
            else if (GarageStorage.NewVehicleForm.VehicleType == eVehicleType.Motorcycle)
            {
                if (GarageStorage.NewVehicleForm.EnergyType == eEnergyType.Electricity)
                {
                    return 1.8f;
                }
                else if (GarageStorage.NewVehicleForm.EnergyType == eEnergyType.Fuel)
                {
                    return 6f;
                }
            }
            else //GarageStorage.NewVehicleForm.VehicleType == eVehicleType.Truck
            {
                return 120f;
            }
            return 0f;
        }
        private string getModelNameFromUser()
        {
            Console.WriteLine("Please enter the vehicle model name: ");
            return Console.ReadLine();
        }
        private eVehicleType getVehicleTypeFromUser()
        {
            bool validInput = false;
            int vehicleType = 0;
            string msg = string.Format(@"Choose vehicle type:
1.Car
2.Motorcycle
3.Truck
");
            Console.WriteLine(msg);
            while (!validInput)
            {
                validInput = true;
                try
                {
                    vehicleType = int.Parse(Console.ReadLine());
                    checkValidity(1, 3, vehicleType);
                }
                catch (ValueOutOfRangeException valueError)
                {
                    Console.WriteLine(valueError.Message);
                    validInput = false;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input, please enter a number");
                    validInput = false;
                }

            }
            return (eVehicleType)vehicleType;
        }
        public void checkValidity(float i_MinValue , float i_MaxValue, float i_ValueToCheck)
        {
            if (i_ValueToCheck > i_MaxValue || i_ValueToCheck < i_MinValue)
            {
                throw new ValueOutOfRangeException(i_MaxValue, i_MinValue);
            }
        }
        private eEnergyType setEnergyTypeFromUser()
        {
            bool validInput = false;
            string msg = string.Format(@"Choose vehicle engine type:
1.Electric 
2.Fuel
");
            Console.WriteLine(msg);
            int energyType = 0;
            while (!validInput)
            {
                validInput = true;
                try
                {
                    energyType = int.Parse(Console.ReadLine());
                }
                catch (ValueOutOfRangeException)
                {
                    validInput = false;
                    new ValueOutOfRangeException(1, 2);
                }
            }
            if  ((eEnergyType)energyType == eEnergyType.Electricity)
            {
                return eEnergyType.Electricity;
            }
            else
            {
                return eEnergyType.Fuel;
            }
        }
        private float getEnergyLeftFromUser()
        {
            bool validInput = false;
            float energyLeftPercentage = 0, amountOfEnegyLeft = 0;
            while (!validInput)
            {
                Console.WriteLine("Please enter the current {0} % of the vehicle: ", GarageStorage.NewVehicleForm.EnergyType);
                try
                {
                    energyLeftPercentage = float.Parse(Console.ReadLine());
                    checkValidity(0, 100, energyLeftPercentage);
                }
                catch (ValueOutOfRangeException e)
                {
                    Console.WriteLine(e.Message);
                    validInput = false;
                }
                catch (FormatException)
                {
                    Console.WriteLine("{0} is not an integer.", energyLeftPercentage);
                    validInput = false;
                }
                validInput = true;
            }
            amountOfEnegyLeft = calculateEnergyFromPercentage(energyLeftPercentage);
            return amountOfEnegyLeft;
        }
        private float calculateEnergyFromPercentage(float i_EnergyLeftPercentage)
        {
            if (GarageStorage.NewVehicleForm.VehicleType == eVehicleType.Car)
            {
                if (GarageStorage.NewVehicleForm.EnergyType == eEnergyType.Electricity)
                {
                    return i_EnergyLeftPercentage * (3.2f);
                    
                }
                else if (GarageStorage.NewVehicleForm.EnergyType == eEnergyType.Fuel)
                {
                    return i_EnergyLeftPercentage * (3.2f);
                }
            }
            else if (GarageStorage.NewVehicleForm.VehicleType == eVehicleType.Motorcycle)
            {
                if (GarageStorage.NewVehicleForm.EnergyType == eEnergyType.Electricity)
                {
                    return i_EnergyLeftPercentage * (1.8f);
                }
                else if (GarageStorage.NewVehicleForm.EnergyType == eEnergyType.Fuel)
                {
                    return i_EnergyLeftPercentage * (6f);
                }
            }
            else //GarageStorage.NewVehicleForm.VehicleType == eVehicleType.Truck
            {
                return i_EnergyLeftPercentage * (120f);
            }
            return 0;
        }
        private float getWheelsAirPressure()
        {
            bool isValidInput = false;
            float wheelsAirPressure = 0;
            while (isValidInput == false)
            {
                isValidInput = true;
                Console.WriteLine("Please enter the current wheels air pressure: ");
                try
                {
                    wheelsAirPressure = float.Parse(Console.ReadLine());
                    if (GarageStorage.NewVehicleForm.VehicleType == eVehicleType.Car)
                    {
                        checkValidity(0, 32, wheelsAirPressure);
                    }
                    else if (GarageStorage.NewVehicleForm.VehicleType == eVehicleType.Truck)
                    {
                        checkValidity(0, 26, wheelsAirPressure);
                    }
                    else //(VehicleType == eVehicleType.Motorcycle)
                    {
                        checkValidity(0, 30, wheelsAirPressure);
                    }
                }
                catch (ValueOutOfRangeException e)
                {
                    Console.WriteLine(e.Message);
                    isValidInput = false;
                }
                catch (FormatException)
                {
                    Console.WriteLine("{0} is not an integer.", wheelsAirPressure);
                    isValidInput = false;
                }
            }
            return wheelsAirPressure;
        }
        private string getOwnerName()
        {
            Console.WriteLine("Please enter owner's name: ");
            bool validInput = false;
            string ownerName = string.Empty;
            while (!validInput)
            {
                validInput = true;
                ownerName = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(ownerName) || string.IsNullOrEmpty(ownerName))
                {
                    Console.WriteLine("Please enter a valid name");
                    validInput = false;
                }
            }
            return ownerName;
        }
        private string getPhone()
        {
            string phoneNumber = string.Empty;
            Console.WriteLine("Please enter owner's phone number: ");
            bool validInput = false;
            while (!validInput)
            {
                validInput = true;
                phoneNumber = Console.ReadLine();
                if (phoneNumber.Length < 1 || phoneNumber.Length > 10)
                {
                    validInput = false;
                }
                foreach (char ch in phoneNumber)
                {
                    if (char.IsDigit(ch) == false)
                    {
                        validInput = false;
                    }
                }
                if (validInput == false)
                {
                    Console.WriteLine("Please enter valid 1-10 digits phone number: ");
                }
            }
            return phoneNumber;
        }
    }
}
