using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class ElectricEngine : Engine
    {

        public ElectricEngine(float i_MaxEnergy, float i_CurrentEnergy) : base(i_MaxEnergy, i_CurrentEnergy)
        {
            //Empty CTOR
        }
        void ChargeVehicle(float i_HoursToAdd)
        {
            if (i_HoursToAdd + CurrentEnergy > MaximumEnergy)
            {
                float maxAllowedCharge = MaximumEnergy - CurrentEnergy;
                throw new ValueOutOfRangeException(0, maxAllowedCharge);
            }
            CurrentEnergy += i_HoursToAdd;
        }
    }
}
