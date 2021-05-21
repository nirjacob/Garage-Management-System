using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        protected string m_ModelName;
        protected string m_OwnerName;
        protected string m_OwnerPhone;
        protected float m_EnergyLeftPercentage;
        protected string m_WheelManufactureName;
        protected float m_CurrentWheelsAirPressure;
        private string m_LicensePlateNumber;
        private List<Wheel> m_VehicleWheels;
        private eVehicleStatus m_CarStatus;
        private Engine m_Engine;
        internal List<Wheel> VehicleWheels
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
        internal Engine Engine
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
        public float EnergyLeftPercentage
        {
            get
            {
                return m_EnergyLeftPercentage;
            }
            set
            {
                m_EnergyLeftPercentage = value;
            }
        } 
        public float CurrentWheelsAirPressure
        {
            get
            {
                return m_CurrentWheelsAirPressure;
            }
            set
            {
                m_CurrentWheelsAirPressure = value;
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
        public eEnergyType VehicleEnergyType
        {
            get
            {
                return m_Engine.EnergyType;
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
        internal abstract int NumberOfWheels();
        internal abstract int ManufactureMaxWheelAirPressure();
        internal abstract float MaximumEnergyCapacity();
        internal abstract eEnergyType EnergyType();
        internal void inflateTire(float i_AirToAdd)
        {
            foreach (Wheel wheel in m_VehicleWheels)
            {
                try
                {
                    wheel.InflateTire(i_AirToAdd);
                }
                catch (ValueOutOfRangeException)
                {
                    Console.WriteLine("Current pressure is: {0}", wheel.CurrentAirPressure);
                    throw new ValueOutOfRangeException(0, wheel.MaximumAirPressure);
                }
            }
        }
        internal float calculateEnergyFromPercentage()
        {
            return (m_EnergyLeftPercentage / 100) * m_Engine.MaximumEnergy;
        }
        public void SetEngine()
        {
            m_Engine = new Engine();
            m_Engine.MaximumEnergy = MaximumEnergyCapacity();
            m_Engine.EnergyType = EnergyType();
            m_Engine.CurrentEnergy = calculateEnergyFromPercentage();
        }
        public void SetWheels()
        {
            int maxAirPressure = this.ManufactureMaxWheelAirPressure();
            int numberOfWheels = this.NumberOfWheels();
            m_VehicleWheels = new List<Wheel>(numberOfWheels);
            for (int i = 0; i < numberOfWheels; i++)
            {
                m_VehicleWheels.Add(new Wheel(m_WheelManufactureName, m_CurrentWheelsAirPressure, maxAirPressure));
            }
        }
        public void SetCarStatus(eVehicleStatus i_Status)
        {
            CarStatus = i_Status;
        }
        public void ChargeVehicle(int i_ChargingTime)
        {
            float timeToAdd = i_ChargingTime;
            timeToAdd /= 60; 
            if (Engine.EnergyType != eEnergyType.Electricity)
            {
                throw new ArgumentException("Vehicle is not electric!");
            }
            if (Engine.CurrentEnergy + timeToAdd > Engine.MaximumEnergy)
            {
                throw new ValueOutOfRangeException(0, (Engine.MaximumEnergy*60));
            }
            Engine.CurrentEnergy += (timeToAdd);
            EnergyLeftPercentage = (Engine.CurrentEnergy / Engine.MaximumEnergy) * 100;
        }
        public void FuelVehicle(int i_AmmountToAdd,eEnergyType i_EnergyType)
        {
            if(i_EnergyType != Engine.EnergyType || Engine.EnergyType == eEnergyType.Electricity)
            {
                throw new ArgumentException("Wrong fuel type");
            }
            if(Engine.CurrentEnergy + i_AmmountToAdd > Engine.MaximumEnergy)
            {
                throw new ValueOutOfRangeException(0, Engine.MaximumEnergy - Engine.CurrentEnergy);
            }
            Engine.CurrentEnergy += i_AmmountToAdd;
            EnergyLeftPercentage = (Engine.CurrentEnergy / Engine.MaximumEnergy) * 100;
        }
        public void InflateTireToMax()
        {
            foreach(Wheel wheel in VehicleWheels)
            {
                try
                {
                    wheel.InflateTire(wheel.MaximumAirPressure- wheel.CurrentAirPressure);
                }
                catch(ValueOutOfRangeException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
