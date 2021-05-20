using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        Dictionary<string,Vehicle> m_VehiclesInGarage;
        VehicleForm m_NewVehicleForm;
        VehicleFactory m_VehicleCreator;
        public Garage()
        {
            m_VehiclesInGarage = new Dictionary<string, Vehicle>();
            m_NewVehicleForm = new VehicleForm();
            m_VehicleCreator = new VehicleFactory();
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
        public VehicleFactory VehicleCreator
        {
            get
            {
                return m_VehicleCreator;
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

        public List<string> GetSupportedVehicles()
        {
            List<string> supportedVehicles = new List<string>();
            foreach (string vehicle in Enum.GetNames(typeof(VehicleFactory.eSupportedVehicles)))
            {
                supportedVehicles.Add(vehicle);
            }
            return supportedVehicles;
        }

        
        //public void CreateNewMotorcycle(eLicenseType i_LicenseType, int i_EngineCapacity)
        //{
        //    Vehicle toAdd = VehicleFactory.BuildNewMotorcycle(i_LicenseType, i_EngineCapacity, ref m_NewVehicleForm);
        //    GarageVehicles.Add(NewVehicleForm.LicensePlate, toAdd);
        //}
        //public void CreateNewCar(eVehicleColor vehicleColor, eNumberOfDoors numOfDoors)
        //{
        //    Vehicle toAdd = VehicleFactory.BuildNewCar(vehicleColor, numOfDoors,ref m_NewVehicleForm);
        //    GarageVehicles.Add(NewVehicleForm.LicensePlate,toAdd);
        //}
        //public void CreateNewTruck(bool v_HazardousMaterial, float i_MaxCarryingWeight)
        //{
        //    Vehicle toAdd = VehicleFactory.BuildNewTruck(v_HazardousMaterial, i_MaxCarryingWeight,ref m_NewVehicleForm);
        //    GarageVehicles.Add(NewVehicleForm.LicensePlate, toAdd);
        //}
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
