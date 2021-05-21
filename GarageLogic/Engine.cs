namespace Ex03.GarageLogic
{
    internal class Engine
    {
        private eEnergyType m_EnergyType;
        private float m_CurrentEnergy;
        private float m_MaximumEnergy;
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
    }
}
