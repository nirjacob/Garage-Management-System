namespace Ex03.GarageLogic
{
    internal abstract class Motorcycle : Vehicle
    {
        protected int m_EngineCapacity;
        protected eLicenseType m_LicenseType;
        public int EngineCapacity
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
        public eLicenseType LicenseType
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
        internal override int NumberOfWheels()
        {
            return 2;
        }
        internal override int ManufactureMaxWheelAirPressure()
        {
            return 30;
        }
    }
}
