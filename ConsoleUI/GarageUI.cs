using System;
using System.Collections.Generic;
using System.Threading;
using System.Reflection;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    class GarageUI
    {
        Garage m_Garage;
        internal Garage GarageStorage
        {
            get
            {
                return m_Garage;
            }
        }
        internal GarageUI()
        {
            m_Garage = new Garage();
        }
        internal void run()
        {
            bool programRunning = true;
            eActionType action;
            while (programRunning)
            {
                printMenuOptions();
                action = readAction();
                takeAction(action);
                Thread.Sleep(500);
            }
        }
        internal eActionType readAction()
        {
            string input = Console.ReadLine();
            int action = -1;
            try
            {
                action = int.Parse(input);
            }
            catch (FormatException)
            {
                Console.Write("Please enter a valid action (number between 1-9): ");
            }
            return (eActionType)action;
        }
        internal void takeAction(eActionType action)
        {
            switch (action)
            {
                case eActionType.InsertNewCar:
                    insertNewVehicle();
                    break;
                case eActionType.DisplayLicensePlates:
                    displayLicensePlatesList();
                    break;
                case eActionType.ChangeVehicleStatus:
                    changeVehicleStatus();
                    break;
                case eActionType.InflateTireToMaximum:
                    inflateTiersToMaximum();
                    break;
                case eActionType.FuelVehicle:
                    fuelVehicle();
                    break;
                case eActionType.ChargeElectric:
                    chargeVehicle();
                    break;
                case eActionType.DisplayCarDetails:
                    displayCarDetails();
                    break;
                default:
                    break;
            }
        }
        internal void chargeVehicle()
        {
            string licensePlate = getLicensePlate();
            if (GarageStorage.VehicleAlreadyInGarage(licensePlate))
            {
                Console.Write("Please enter the number of minutes you want to charge: ");
                int chargingTime = readIntFromUser();
                try
                {
                    GarageStorage.ChargeVehicleInGarage(licensePlate, chargingTime);
                    Console.WriteLine("Vehicle: {0} charged, with {1}% charge left", licensePlate, GarageStorage.GarageVehicles[licensePlate].EnergyLeftPercentage);
                    Thread.Sleep(500);
                }
                catch (ValueOutOfRangeException e)
                {
                    Console.WriteLine(e.Message);
                    pressAnyKeyToContinueMsg();
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                    pressAnyKeyToContinueMsg();
                }
            }
            else
            {
                vehicleNotFoundErrorMsg();
            }
        }
        internal void fuelVehicle()
        {
            string licensePlate = getLicensePlate();
            if (GarageStorage.VehicleAlreadyInGarage(licensePlate))
            {
                try
                { 
                    Console.Write("Please enter vehicle fuel type: ");
                    int fuelType = readEnumFromUser(typeof(eEnergyType));
                    Console.Write("Please enter the amount of fuel in liters you want to add: ");
                    int fuelAmmount = readIntFromUser();
                    GarageStorage.FuelVehicleInGarage(licensePlate, fuelAmmount, (eEnergyType)fuelType);
                    Console.WriteLine("Vehicle: {0} fueled, with {1}% fuel left", licensePlate, GarageStorage.GarageVehicles[licensePlate].EnergyLeftPercentage);
                    Thread.Sleep(500);
                }
                catch (ValueOutOfRangeException e)
                {
                    Console.WriteLine(e.Message);
                    pressAnyKeyToContinueMsg();
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                    pressAnyKeyToContinueMsg();
                }
            }
            else
            {
                vehicleNotFoundErrorMsg();
            }
        }
        internal void changeVehicleStatus()
        {
            string licensePlate = getLicensePlate();
            if (GarageStorage.VehicleAlreadyInGarage(licensePlate))
            {
                try
                {
                    Console.Write("Please choose desired vehicle status: ");
                    int statusChoise = readEnumFromUser(typeof(eVehicleStatus));
                    GarageStorage.SetVehicleStatus(licensePlate, (eVehicleStatus)statusChoise);
                    Console.WriteLine("Vehicle: {0} status changed!", licensePlate);
                }
                catch(ValueOutOfRangeException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else
            {
                vehicleNotFoundErrorMsg();
            }
        }
        internal void inflateTiersToMaximum()
        {
            string licensePlate = getLicensePlate();
            if (GarageStorage.VehicleAlreadyInGarage(licensePlate))
            {
                GarageStorage.InflateToMax(licensePlate);
                Console.WriteLine("Vehicle: {0} tiers inflated to the maximum!", licensePlate);
                Thread.Sleep(500);
            }
            else
            {
                vehicleNotFoundErrorMsg();
            }
        }
        internal void vehicleNotFoundErrorMsg()
        {
            Console.WriteLine("Error, invalid license plate entered or vehicle is not in the garage");
        }
        internal void printMenuOptions()
        {
            Console.Clear();
            string mainMenu = string.Format(@" 

-------------------------------------------
1. Insert a vehicle to the garage.         
2. Display all vehicles license number.    
3. Change vehicle garage status.           
4. Inflate vehicle tiers to maximum.                  
5. Fuel vehicle.                
6. Charge vehicle.              
7. Display car details.                    
-------------------------------------------
");
            Console.WriteLine(mainMenu);
        }
        internal string getLicensePlate()
        {
            Console.Write("Please enter the license plate: ");
            string licensePlate = Console.ReadLine();
            return licensePlate;
        }
        internal void insertNewVehicle()
        {
            string licensePlate = getLicensePlate();
            if (GarageStorage.VehicleAlreadyInGarage(licensePlate))
            {
                GarageStorage.SetVehicleStatus(licensePlate, eVehicleStatus.InRepair);
                Console.WriteLine("Vehicle already in the garage, status changed to in repair");
            }
            else
            {
                Console.WriteLine("Please select vehicle type: ");
                List<string> supportedVehicles = GarageStorage.GetSupportedVehicles();
                int choiceIndex = 1;
                foreach (string supportedVehicle in supportedVehicles)
                {
                    Console.WriteLine("{0}.{1}", choiceIndex, supportedVehicle);
                    choiceIndex++;
                }
                try
                {
                    string vehicleChoise = getSupportedVehicleChoice(choiceIndex);
                    Vehicle newVehicle = GarageStorage.CreateNewVehicle(vehicleChoise);
                    getVehicleDetailes(ref newVehicle, licensePlate);
                    checkPercentageValidity(ref newVehicle);
                    GarageStorage.InsertToStorage(licensePlate, ref newVehicle);
                    GarageStorage.SetVehicleStatus(licensePlate, eVehicleStatus.InRepair);
                    Console.WriteLine("Vehicle: {0} inserted to the garage!", licensePlate);
                }
                catch(ValueOutOfRangeException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch(FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
        internal string getSupportedVehicleChoice(int i_NumOfSupportedVehicles)
        {
            int choice = int.Parse(Console.ReadLine());
            if(choice > i_NumOfSupportedVehicles || choice < 1)
            {
                throw new ValueOutOfRangeException(1, i_NumOfSupportedVehicles);
            }
            else
            {
                return choice.ToString();
            }
        }
        internal void checkPercentageValidity(ref Vehicle i_NewVehicle)
        {
            if  (i_NewVehicle.EnergyLeftPercentage > 100 || i_NewVehicle.EnergyLeftPercentage < 0)
            {
                throw new ValueOutOfRangeException(0, 100);
            }
        }
        internal void displayLicensePlatesList()
        {
            string msg = string.Format(@"
Please select the desired filter for displaying license plates:
1. All the vehicles in the garage.
2. Vehicles in repair.
3. Vehicles repaired.
4. Vehicles payed.
");
            Console.WriteLine(msg);
            int userChoice = int.Parse(Console.ReadLine());
            switch (userChoice)
            {
                case 1:
                    displayAllLicensePlates();
                    break;
                case 2:
                    displayVehiclesFiltered(eVehicleStatus.InRepair);
                    break;
                case 3:
                    displayVehiclesFiltered(eVehicleStatus.Repaired);
                    break;
                case 4:
                    displayVehiclesFiltered(eVehicleStatus.Payed);
                    break;
            }
            pressAnyKeyToContinueMsg();
        }
        internal void displayVehiclesFiltered(eVehicleStatus i_Filter)
        {
            int numOfVehiclesDisplayed = 0;
            foreach (Vehicle vehicle in GarageStorage.GarageVehicles.Values)
            {
                if (vehicle.CarStatus == i_Filter)
                {
                    Console.WriteLine(vehicle.LicensePlateNumber);
                    numOfVehiclesDisplayed++;
                }
            }
            if (numOfVehiclesDisplayed == 0)
            {
                noVehiclesToDisplayMsg();
            }
        }
        internal void noVehiclesToDisplayMsg()
        {
            Console.WriteLine("No vehicles in garage");
        }
        internal void displayAllLicensePlates()
        {
            if (GarageStorage.GarageVehicles.Count == 0)
            {
                noVehiclesToDisplayMsg();
            }
            foreach (string licensePlate in GarageStorage.GarageVehicles.Keys)
            {
                Console.WriteLine(licensePlate);
            }
        }
        internal void displayCarDetails()
        {
            string licensePlate = getLicensePlate();
            if (GarageStorage.VehicleAlreadyInGarage(licensePlate))
            { 
                GarageStorage.GarageVehicles.TryGetValue(licensePlate, out Vehicle vehicleToDisplay);
                printCarDetailes(ref vehicleToDisplay, licensePlate);
            }
            else
            {
                vehicleNotFoundErrorMsg();
            }
            pressAnyKeyToContinueMsg();
        }
        internal void printCarDetailes(ref Vehicle i_VehicleToPrint, string i_LicensePlate)
        {
            Type vehicleType = i_VehicleToPrint.GetType();
            FieldInfo[] fields = vehicleType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("License plate: {0}", i_LicensePlate);

            foreach (FieldInfo field in fields)
            {
                string fieldName = getFieldName(field.Name);
                Char.ToUpper(fieldName[0]);
                Console.WriteLine("{0}: {1}", fieldName, field.GetValue(i_VehicleToPrint));
            }
            Console.WriteLine("Energy Type: {0}", i_VehicleToPrint.VehicleEnergyType);
            Console.WriteLine("-------------------------------------------");
        }
        internal void pressAnyKeyToContinueMsg()
        {
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        internal void getVehicleDetailes(ref Vehicle i_NewVehicle, string i_LicensePlate)
        {
            Type vehicleType = i_NewVehicle.GetType();
            FieldInfo[] fields = vehicleType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
            foreach(FieldInfo field in fields)
            {
                string fieldName = getFieldName(field.Name);
                Console.Write("Please enter {0}: ", fieldName);
                if(field.FieldType == typeof(float))
                {
                    float valueFromUser = readFloatFromUser();
                    field.SetValue(i_NewVehicle, valueFromUser);
                }
                else if(field.FieldType == typeof(int))
                {
                    int valueFromUser = readIntFromUser();
                    field.SetValue(i_NewVehicle, valueFromUser);
                }
                else if (field.FieldType == typeof(bool))
                {
                    bool valuefromUser = readBoolFromUser();
                    field.SetValue(i_NewVehicle, valuefromUser);
                }
                else if (field.FieldType == typeof(string))
                {
                    string valueFromUser = readStringFromUser();
                    field.SetValue(i_NewVehicle, valueFromUser);
                }
                else if (field.FieldType.IsEnum)
                {
                    int valueFromUser = readEnumFromUser(field.FieldType);
                    field.SetValue(i_NewVehicle, valueFromUser);
                }
            }
            i_NewVehicle.LicensePlateNumber = i_LicensePlate;
            i_NewVehicle.SetWheels();
            i_NewVehicle.SetEngine();
        }
        internal string getFieldName(string i_FieldName)
        {
            string finalFieldName = i_FieldName;
            bool foundUppercase = false;
            finalFieldName = finalFieldName.Replace("m_", "");
            for (int i = 1; i < finalFieldName.Length; i++)
            {
                if (Char.IsUpper(finalFieldName[i]) && foundUppercase == false)
                {
                    foundUppercase = true;
                    finalFieldName = finalFieldName.Insert(i, " ");
                }
                else
                {
                    foundUppercase = false;
                }
            }
            finalFieldName = finalFieldName.ToLower();
            return finalFieldName;
        }
        internal int readEnumFromUser(Type i_EnumType)
        {
            Console.WriteLine();
            List<string> enumChoises = new List<string>();
            foreach (string enumChoise in Enum.GetNames(i_EnumType))
            {
                enumChoises.Add(enumChoise);
            }
            int choiseIndex = 1;
            foreach (string enumChoise in enumChoises)
            {
                Console.WriteLine("{0}.{1}", choiseIndex, enumChoise);
                choiseIndex++;
            }
            int userChoise = readIntFromUser();
            if (userChoise > choiseIndex|| userChoise < 1)
            {
                throw new ValueOutOfRangeException(1, choiseIndex);
            }
            return userChoise;
        }
        internal string readStringFromUser()
        {
            string inputFromUser = Console.ReadLine();
            return inputFromUser;
        }
        internal float readFloatFromUser()
        {
            float inputFromUser = 0;
            try
            {
                inputFromUser = float.Parse(Console.ReadLine());
            }
            catch(FormatException)
            {
                throw new FormatException("Please enter a number");
            }
            return inputFromUser;
        }
        internal int readIntFromUser()
        {
            int inputFromUser = 0;
            try
            {
                inputFromUser = int.Parse(Console.ReadLine());
            }
            catch(FormatException)
            {
                throw new FormatException("Please enter a number");
            }
            return inputFromUser;
        }
        internal bool readBoolFromUser()
        {
            Console.Write(@"Enter yes/no: ");
            string textInputFromUser = Console.ReadLine();
            bool inputFromUser = false;
            if (textInputFromUser is "yes")
            {
                inputFromUser = true;
            }
            else if (textInputFromUser != "no")
            {
                Console.WriteLine("Please enter yes/no");
            }
            return inputFromUser;
        }
    }
}
