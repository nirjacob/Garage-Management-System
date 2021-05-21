namespace Ex03.GarageLogic
{
    class ElectricMotorcycle : Motorcycle
    {
        internal override float MaximumEnergyCapacity()
        {
            return 1.8f;
        }
        internal override eEnergyType EnergyType()
        {
            return eEnergyType.Electricity;
        }
    }
}
