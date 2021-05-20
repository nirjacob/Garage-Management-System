using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class Car : Vehicle
    {
        protected eVehicleColor m_CarColor;
        protected eNumberOfDoors m_NumOfDoors;
        public Car() : base() 
        { 
        }
        protected enum eVehicleColor
        {
            Red,
            Silver,
            White,
            Black
        }
        protected enum eNumberOfDoors
        {
            TwoDoors,
            ThreeDoors,
            FourDoors,
            FiveDoors
        }
  
        protected eVehicleColor CarColor
        {
            get
            {
                return m_CarColor;
            }
            set
            {
                m_CarColor = value;
            }
        }

        protected eNumberOfDoors NumOfDoors
        {
            get
            {
                return m_NumOfDoors;
            }
            set
            {
                m_NumOfDoors = value;
            }
        }
        //public Car(eVehicleColor i_VehicleColor, eNumberOfDoors i_NumOfDoors, ref VehicleForm i_NewVehicleForm)
        //{
        //    SetWheels(i_NewVehicleForm.WheelManufacturer,i_NewVehicleForm.WheelsAirPressure, i_NewVehicleForm.MaxWheelAirPressure, i_NewVehicleForm.NumOfWheels);
        //    VehicleOwner.OwnerName = i_NewVehicleForm.OwnerName;
        //    VehicleOwner.OwnerPhone = i_NewVehicleForm.OwnerPhone;
        //    EnergyLeft = i_NewVehicleForm.EnergyLeft;
        //    CarStatus = eVehicleStatus.InRepair;
        //    LicensePlateNumber = i_NewVehicleForm.LicensePlate;
        //    ModelName = i_NewVehicleForm.ModelName;
        //    if(i_NewVehicleForm.EnergyType == eEnergyType.Electricity)
        //    {
        //        Engine = new ElectricEngine(i_NewVehicleForm.MaxEnergy, i_NewVehicleForm.EnergyLeft);
        //    }
        //    if(i_NewVehicleForm.EnergyType == eEnergyType.Fuel)
        //    {
        //        Engine = new FuelEngine(i_NewVehicleForm.MaxEnergy, i_NewVehicleForm.EnergyLeft, i_NewVehicleForm.FuelType);
        //    }
        //}
    }
}
