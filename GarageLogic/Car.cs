namespace Ex03.GarageLogic
{
    internal abstract class Car : Vehicle
    {
        protected enum eVehicleColor
        {
            Red = 1,
            Silver,
            White,
            Black
        }
        protected enum eNumberOfDoors
        {
            TwoDoors = 1,
            ThreeDoors,
            FourDoors,
            FiveDoors
        }
        protected eVehicleColor m_CarColor;
        protected eNumberOfDoors m_NumOfDoors;
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
        internal override int NumberOfWheels()
        {
            return 4;
        }
        internal override int ManufactureMaxWheelAirPressure()
        {
            return 32;
        }
    }
}
