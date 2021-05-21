namespace Ex03.GarageLogic
{
    class ElectricCar : Car
    {
        internal override float MaximumEnergyCapacity()
        {
            return 3.2f;
        }
        internal override eEnergyType EnergyType()
        {
            return eEnergyType.Electricity;
        }
    }
}
