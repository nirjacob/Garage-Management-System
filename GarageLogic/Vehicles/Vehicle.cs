using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex3.GarageLogic.Components;
using Ex3.GarageLogic.Enums;
using Ex3.GarageLogic;

namespace Ex3.GarageLogic.Vehicles
{
    class Vehicle
    {
        private string m_ModelName;
        private string m_LicensePlateNumber;
        private float m_EnergyLeft;
        private List<Wheel> m_VehicleWheels;
        private Customer m_VehicleOwner;
        private eVehicleStatus m_CarStatus;
        private Engine m_Engine;

        public List<Wheel> VehicleWheels
        {
            get
            {
                return m_VehicleWheels;
            }
            set
            {
                m_VehicleWheels = value;
            }
        }
        public Engine Engine
        {
            get
            {
                return m_Engine;
            }
            set
            {
                m_Engine = value;
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
        public string LicensePlateNumber
        {
            get
            {
                return m_LicensePlateNumber;
            }
            set
            {
                m_LicensePlateNumber = value;
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
        public void SetWheels(string i_ManufactureName, float i_CurrentAirPressure,float i_MaximumAirPressure,int i_NumberOfWheels)
        {
            m_VehicleWheels = new List<Wheel>();
            for (int i = 0; i < i_NumberOfWheels; i++)
            {
                m_VehicleWheels.Add(new Wheel(i_ManufactureName, i_CurrentAirPressure, i_MaximumAirPressure));
            }
        }
        public Customer VehicleOwner
        {
            get
            {
                return m_VehicleOwner;
            }
            set
            {
                m_VehicleOwner = value;
            }
        }
        public eVehicleStatus CarStatus
        {
            get
            {
                return m_CarStatus;
            }
            set
            {
                m_CarStatus = value;
            }
        }
        public void SetCarStatus(eVehicleStatus i_Status)
        {
            CarStatus = i_Status;
        }

        public void InflateTireToMax()
        {
            foreach(Wheel wheel in VehicleWheels)
            {
                wheel.InflateTire(wheel.MaximumAirPressure- wheel.CurrentAirPressure);
            }
        }
        public void InflateTire(float i_AirToAdd)
        {
            foreach(Wheel wheel in m_VehicleWheels)
            {
                try
                {
                  wheel.InflateTire(i_AirToAdd);
                }
                catch(ValueOutOfRangeException)
                {
                    Console.WriteLine("Current pressure is: {0}", wheel.CurrentAirPressure);
                    throw new ValueOutOfRangeException(0,  wheel.MaximumAirPressure);
                }
            }
        }
    }
}
