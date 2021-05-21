namespace Ex03.GarageLogic
{
    class Truck : Vehicle
    {
        protected float m_MaximumCarryingCapacityInKg;
        protected bool m_IsCarryingHazardousMaterials;
        public float MaximumCarry
        {
            get
            {
                return m_MaximumCarryingCapacityInKg;
            }
            set
            {
                m_MaximumCarryingCapacityInKg = value;
            }
        }
        public bool IsCarryDangerousGoods
        {
            get
            {
                return m_IsCarryingHazardousMaterials;
            }
            set
            {
                m_IsCarryingHazardousMaterials = value;
            }
        }
        internal override eEnergyType EnergyType()
        {
            return eEnergyType.Soler;
        }
        internal override float MaximumEnergyCapacity()
        {
            return 120f;
        }
        internal override int NumberOfWheels()
        {
            return 16;
        }
        internal override int ManufactureMaxWheelAirPressure()
        {
            return 26;
        }
    }
}
