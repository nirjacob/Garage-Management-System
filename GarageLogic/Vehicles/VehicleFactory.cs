using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Ex03.GarageLogic
{
    public class VehicleFactory
    {
        internal enum eSupportedVehicles
        {
            FuelCar = 1,
            FuelMotorcycle,
            ElectricCar,
            ElectricMotorcycle,
            Truck
        }
        public Vehicle CreateVehicle(string i_VehicleType)
        {
            eSupportedVehicles vehicleToCreate = (eSupportedVehicles)Enum.Parse(typeof(eSupportedVehicles), i_VehicleType);
            
            switch (vehicleToCreate)
            {
                case eSupportedVehicles.FuelCar:
                    return new FuelCar();
                    break;
                case eSupportedVehicles.FuelMotorcycle:
                    return new FuelMotorcycle();
                    break;
                case eSupportedVehicles.ElectricCar:
                    return new ElectricCar();
                    break;
                case eSupportedVehicles.ElectricMotorcycle:
                    return new ElectricMotorcycle();
                    break;
                case eSupportedVehicles.Truck:
                    return new Truck();
                    break;
                default:
                    return null;
                    break;
            }
        }

        //internal static Vehicle BuildNewTruck(bool v_HazardousMaterial,float i_MaxCarryingWeight, ref VehicleForm i_NewVehicleForm)
        //{
        //    return new Truck(v_HazardousMaterial, i_MaxCarryingWeight, ref i_NewVehicleForm);
        //}
        //internal static Vehicle BuildNewMotorcycle(eLicenseType i_LicenseType, int i_EngineCapacity,ref VehicleForm i_NewVehicleForm)
        //{
        //    return new Motorcycle(i_LicenseType, i_EngineCapacity, ref i_NewVehicleForm);
        //}
        //internal static Vehicle BuildNewCar(eVehicleColor i_VehicleColor, eNumberOfDoors i_NumOfDoors, ref VehicleForm i_NewVehicleForm)
        //{
        //    return new Car(i_VehicleColor, i_NumOfDoors, ref i_NewVehicleForm);

        //}
    }
}
