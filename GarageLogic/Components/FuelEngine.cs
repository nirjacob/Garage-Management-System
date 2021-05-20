using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Ex03.GarageLogic
{
    public class FuelEngine : Engine
    {
        eFuelType m_FuelType;

        float CurrentFuel
        {
            get
            {
                return CurrentEnergy;
            }
            set
            {
                CurrentEnergy = value;
            }
        }
        float TankCapacity
        {
            get
            {
                return MaximumEnergy;
            }
            set
            {
                MaximumEnergy = value;
            }
        }
        eFuelType FuelType
        {
            get
            {
                return m_FuelType;
            }
            set
            {
                m_FuelType = value;
            }
        }
        public FuelEngine(float i_MaxEnergy, float i_CurrentEnergy, eFuelType i_FuelType) : base(i_MaxEnergy, i_CurrentEnergy)
        {

            this.FuelType = i_FuelType;
        }
        void FuelVehicle(float i_FuelToAdd, eFuelType i_FuelType)
        {
            if(this.FuelType.Equals(i_FuelType) == false)
            {
                throw new ArgumentException("Invalid fuel type");
            }
            if(i_FuelToAdd + CurrentFuel > TankCapacity)
            {
                float maxAllowedCharge = TankCapacity - CurrentFuel;
                throw new ValueOutOfRangeException(0, maxAllowedCharge);
            }
            CurrentFuel += i_FuelToAdd;
        }
    }
}
