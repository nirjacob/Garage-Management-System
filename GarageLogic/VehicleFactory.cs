using System;
namespace Ex03.GarageLogic
{
    public class VehicleFactory
    {
        internal enum eSupportedVehicles
        {
            FuelCar = 1,
            ElectricCar,
            FuelMotorcycle,
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
                case eSupportedVehicles.FuelMotorcycle:
                    return new FuelMotorcycle();
                case eSupportedVehicles.ElectricCar:
                    return new ElectricCar();
                case eSupportedVehicles.ElectricMotorcycle:
                    return new ElectricMotorcycle();
                case eSupportedVehicles.Truck:
                    return new Truck();
                default:
                    return null;
            }
        }
    }
}
