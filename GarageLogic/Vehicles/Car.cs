using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex3.GarageLogic.Enums;
using Ex3.GarageLogic.Components;

namespace Ex3.GarageLogic.Vehicles
{
    class Car : Vehicle
    {
        private eVehicleColor m_CarColor;
        private eNumberOfDoors m_NumOfDoors;

        public eVehicleColor CarColor
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

        public eNumberOfDoors NumOfDoors
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
        public Car(eVehicleColor i_VehicleColor, eNumberOfDoors i_NumOfDoors, ref VehicleForm i_NewVehicleForm)
        {
            SetWheels(i_NewVehicleForm.WheelManufacturer,i_NewVehicleForm.WheelsAirPressure, i_NewVehicleForm.MaxWheelAirPressure, i_NewVehicleForm.NumOfWheels);
            VehicleOwner.OwnerName = i_NewVehicleForm.OwnerName;
            VehicleOwner.OwnerPhone = i_NewVehicleForm.OwnerPhone;
            EnergyLeft = i_NewVehicleForm.EnergyLeft;
            CarStatus = eVehicleStatus.InRepair;
            LicensePlateNumber = i_NewVehicleForm.LicensePlate;
            ModelName = i_NewVehicleForm.ModelName;
            if(i_NewVehicleForm.EnergyType == eEnergyType.Electricity)
            {
                Engine = new ElectricEngine(i_NewVehicleForm.MaxEnergy, i_NewVehicleForm.EnergyLeft);
            }
            if(i_NewVehicleForm.EnergyType == eEnergyType.Fuel)
            {
                Engine = new FuelEngine(i_NewVehicleForm.MaxEnergy, i_NewVehicleForm.EnergyLeft, i_NewVehicleForm.FuelType);
            }
        }
    }
}
