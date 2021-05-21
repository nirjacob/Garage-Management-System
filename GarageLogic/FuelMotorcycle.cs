namespace Ex03.GarageLogic
{
    class FuelMotorcycle : Motorcycle
    {
        internal override float MaximumEnergyCapacity()
        {
            return 45f;
        }
        internal override eEnergyType EnergyType()
        {
            return eEnergyType.Octan98;
        }
    }
}
