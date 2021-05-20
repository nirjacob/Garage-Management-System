using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Wheel
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
                string msg = string.Format(@"Added air pressure exceeds manufacturer maximum air pressure limit of: {0:D}. 
You can only add up to {1:D}.", MaximumAirPressure, (MaximumAirPressure - CurrentAirPressure));
                Console.WriteLine(msg);
            }
            else
            {
                m_CurrentAirPressure += i_AirToAdd;
            }

        }
    }
}
