using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Ex03.GarageLogic
{
    public class Engine
    {
        float m_CurrentEnergy;
        float m_MaximumEnergy;

        public float CurrentEnergy
        {
            get
            {
                return m_CurrentEnergy;
            }
            set
            {
                m_CurrentEnergy = value;
            }
        }
        public float MaximumEnergy
        {
            get
            {
                return m_MaximumEnergy;
            }
            set
            {
                m_MaximumEnergy = value;
            }
        }
        public Engine(float i_MaxEnergy, float i_CurrentEnergy)
        {
            this.m_MaximumEnergy = i_MaxEnergy;
            this.m_CurrentEnergy = i_CurrentEnergy;
        }
    }
}
