using System;
using System.Collections.Generic;
using Ex3.GarageLogic.Vehicles;
using Ex3.GarageLogic.Enums;

namespace Ex3.GarageLogic
{
    public class Garage
    {
        Dictionary<string,Vehicle> m_VehiclesInGarage;
        VehicleForm m_NewVehicleForm;
        public Garage()
        {
            m_VehiclesInGarage = new Dictionary<string, Vehicle>();
            m_NewVehicleForm = new VehicleForm();
        }
        public VehicleForm NewVehicleForm
        {
            get
            {
                return m_NewVehicleForm;
            }
            set
            {
                m_NewVehicleForm = value;
            }
        }
        Dictionary<string, Vehicle> GarageVehicles
        {
            get
            {
                return m_VehiclesInGarage;
            }
        }
        public void InflateToMax(string i_LicensePlate)
        {

            GarageVehicles[i_LicensePlate].InflateTireToMax();
        }
        
        public void CreateNewMotorcycle(eLicenseType i_LicenseType, int i_EngineCapacity)
        {
            Vehicle toAdd = VehicleFactory.BuildNewMotorcycle(i_LicenseType, i_EngineCapacity, ref m_NewVehicleForm);
            GarageVehicles.Add(NewVehicleForm.LicensePlate, toAdd);
        }
        public void CreateNewCar(eVehicleColor vehicleColor, eNumberOfDoors numOfDoors)
        {
            Vehicle toAdd = VehicleFactory.BuildNewCar(vehicleColor, numOfDoors,ref m_NewVehicleForm);
            GarageVehicles.Add(NewVehicleForm.LicensePlate,toAdd);
        }
        public void CreateNewTruck(bool v_HazardousMaterial, float i_MaxCarryingWeight)
        {
            Vehicle toAdd = VehicleFactory.BuildNewTruck(v_HazardousMaterial, i_MaxCarryingWeight,ref m_NewVehicleForm);
            GarageVehicles.Add(NewVehicleForm.LicensePlate, toAdd);
        }
        public bool AlreadyInGarage(string i_LicensePlate)
        {
            return GarageVehicles.ContainsKey(i_LicensePlate);
        }
        public void setVehicleStatus(string i_LicensePlate, eVehicleStatus i_NewStatus)
        {
            GarageVehicles[i_LicensePlate].CarStatus = i_NewStatus;
        }

    }
}
