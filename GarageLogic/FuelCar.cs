namespace Ex03.GarageLogic
{
    class FuelCar : Car
    {
        internal override float MaximumEnergyCapacity()
        {
            return 45f;
        }
        internal override eEnergyType EnergyType()
        {
            return eEnergyType.Octan95;
        }
    }
}
