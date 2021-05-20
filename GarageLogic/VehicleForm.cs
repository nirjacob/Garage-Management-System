using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class VehicleForm
    {
        eVehicleType m_VehicleType;
        eEnergyType m_EnergyType;
        eFuelType m_FuelType;
        float m_EnergyLeft;
        float m_MaxEnergy;
        string m_WheelsManufacturer;
        float m_MaxWheelAirPressure;
        float m_WheelsAirPressure;
        int m_NumOfWheels;
        string m_ModelName;
        string m_OwnerName;
        string m_OwnerPhone;
        string m_LicensePlate;

        public float MaxWheelAirPressure
        {
            get
            {
                 return m_MaxWheelAirPressure;
            }
            set
            {
                m_MaxWheelAirPressure = value;
            }
        }
        public string WheelManufacturer
        {
            get
            {
                return m_WheelsManufacturer;
            }
            set
            {
                m_WheelsManufacturer = value;
            }
        }
        public int NumOfWheels
        {
            get
            {
                return m_NumOfWheels;
            }
            set
            {
                m_NumOfWheels = value;
            }
        }
        public eFuelType FuelType
        {
            get
            {
                return m_FuelType;
            }
            set
            {
                m_FuelType = value;
            }
        }
        public float MaxEnergy
        {
            get
            {
                return m_MaxEnergy;
            }
            set
            {
                m_MaxEnergy = value;
            }
        }
        public eVehicleType VehicleType
        {
            get
            {
                return m_VehicleType;
            }
            set
            {
                m_VehicleType = value;
            }
        }
        public eEnergyType EnergyType
        {
            get
            {
                return m_EnergyType;
            }
            set
            {
                m_EnergyType = value;
            }
        }
        public float EnergyLeft
        {
            get
            {
                return m_EnergyLeft;
            }
            set
            {
                m_EnergyLeft = value;
            }
        }
        public float WheelsAirPressure
        {
            get
            {
                return m_WheelsAirPressure;
            }
            set
            {
                m_WheelsAirPressure = value;
            }
        }
        public string ModelName
        {
            get
            {
                return m_ModelName;
            }
            set
            {
                m_ModelName = value;
            }
        }
        public string OwnerName
        {
            get
            {
                return m_OwnerName;
            }
            set
            {
                m_OwnerName = value;
            }
        }
        public string OwnerPhone
        {
            get
            {
                return m_OwnerPhone;
            }
            set
            {
                m_OwnerPhone = value;
            }
        }

        public string LicensePlate
        {
            get
            {
                return m_LicensePlate;
            }
            set
            {
                m_LicensePlate = value;
            }
        }

    }
}
