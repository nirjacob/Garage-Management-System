using System;
namespace Ex03.GarageLogic
{
    internal class Wheel
    {
        private string m_ManufactureName;
        private float m_CurrentAirPressure;
        private float m_MaximumAirPressure;
        public Wheel(string i_ManufactureName, float i_CurrentAirPressure, float i_MaximumAirPressure)
        {
            ManufactureName = i_ManufactureName;
            CurrentAirPressure = i_CurrentAirPressure;
            MaximumAirPressure = i_MaximumAirPressure;
        }
        public string ManufactureName
        {
            get
            {
                return m_ManufactureName;
            }
            set
            {
                m_ManufactureName = value;
            }
        }
        public float CurrentAirPressure
        {
            get
            {
                return m_CurrentAirPressure;
            }
            set
            {
                m_CurrentAirPressure = value;
            }
        }
        public float MaximumAirPressure
        {
            get
            {
                return m_MaximumAirPressure;
            }
            set
            {
                m_MaximumAirPressure = value;
            }

        }

        public void InflateTire(float i_AirToAdd)
        {

            if (MaximumAirPressure < CurrentAirPressure + i_AirToAdd)
            {
                throw new ValueOutOfRangeException(MaximumAirPressure, (MaximumAirPressure - CurrentAirPressure));
            }
            else
            {
                m_CurrentAirPressure += i_AirToAdd;
            }

        }
    }
}
