using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class Motorcycle : Vehicle
    {

        private eLicenseType m_LicenseType;
        private int m_EngineCapacity;
        eLicenseType LicenseType
        {
            get
            {
                return m_LicenseType;
            }
            set
            {
                m_LicenseType = value;
            }
        }
        int EngineCapacity
        {
            get
            {
                return m_EngineCapacity;
            }
            set
            {
                m_EngineCapacity = value;
            }
        }
        public Motorcycle() : base()
        {
            
        }
        //public Motorcycle(eLicenseType i_LicenseType, int i_EngineCapacity, ref VehicleForm i_NewVehicleForm)
        //{
        //    VehicleOwner.OwnerName = i_NewVehicleForm.OwnerName;
        //    VehicleOwner.OwnerPhone = i_NewVehicleForm.OwnerPhone;
        //    EnergyLeft = i_NewVehicleForm.EnergyLeft;
        //    CarStatus = eVehicleStatus.InRepair;
        //    LicensePlateNumber = i_NewVehicleForm.LicensePlate;
        //    ModelName = i_NewVehicleForm.ModelName;
        //    EngineCapacity = i_EngineCapacity;
        //    LicenseType = i_LicenseType;
        //    if(i_NewVehicleForm.EnergyType== eEnergyType.Fuel)
        //    {
        //        Engine = new FuelEngine(i_NewVehicleForm.MaxEnergy, i_NewVehicleForm.EnergyLeft, i_NewVehicleForm.FuelType);
        //    }
        //    else
        //    {
        //        Engine = new ElectricEngine(i_NewVehicleForm.MaxEnergy, i_NewVehicleForm.EnergyLeft);
        //    }
        //}
    }
}
