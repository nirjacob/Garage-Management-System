using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex3.GarageLogic.Enums;
using Ex3.GarageLogic.Components;
namespace Ex3.GarageLogic.Vehicles
{
    class Truck : Vehicle
    {
        private bool m_IsCarryDangerousGoods;
        float m_MaximumCarry;
        
        public float MaximumCarry
        {
            get
            {
                return m_MaximumCarry;
            }
            set
            {
                m_MaximumCarry = value;
            }
        }
        public bool IsCarryDangerousGoods
        {
            get
            {
                return m_IsCarryDangerousGoods;
            }
            set
            {
                m_IsCarryDangerousGoods = value;
            }
        }
        public Truck(bool i_IsCarryDangerousGoods, float i_MaximumCarry, ref VehicleForm i_NewVehicleForm)
        {
            VehicleOwner.OwnerName = i_NewVehicleForm.OwnerName;
            VehicleOwner.OwnerPhone = i_NewVehicleForm.OwnerPhone;
            EnergyLeft = i_NewVehicleForm.EnergyLeft;
            CarStatus = eVehicleStatus.InRepair;
            LicensePlateNumber = i_NewVehicleForm.LicensePlate;
            ModelName = i_NewVehicleForm.ModelName;
            Engine = new FuelEngine(i_NewVehicleForm.MaxEnergy, i_NewVehicleForm.EnergyLeft, i_NewVehicleForm.FuelType);
        }
    }
}
