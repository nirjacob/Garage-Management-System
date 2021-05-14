using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex3.GarageLogic.Enums;
namespace Ex3.GarageLogic.Vehicles
{
    internal class VehicleFactory
    {
        internal static Vehicle BuildNewTruck(bool v_HazardousMaterial,float i_MaxCarryingWeight, ref VehicleForm i_NewVehicleForm)
        {
            return new Truck(v_HazardousMaterial, i_MaxCarryingWeight, ref i_NewVehicleForm);
        }
        internal static Vehicle BuildNewMotorcycle(eLicenseType i_LicenseType, int i_EngineCapacity,ref VehicleForm i_NewVehicleForm)
        {
            return new Motorcycle(i_LicenseType, i_EngineCapacity, ref i_NewVehicleForm);
        }
        internal static Vehicle BuildNewCar(eVehicleColor i_VehicleColor, eNumberOfDoors i_NumOfDoors, ref VehicleForm i_NewVehicleForm)
        {
            return new Car(i_VehicleColor, i_NumOfDoors, ref i_NewVehicleForm);

        }
    }
}
