using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private Dictionary<string,Vehicle> m_VehiclesInGarage;
        private VehicleFactory m_VehicleCreator;
        public Garage()
        {
            m_VehiclesInGarage = new Dictionary<string, Vehicle>();
            m_VehicleCreator = new VehicleFactory();
        }
        private VehicleFactory VehicleCreator
        {
            get
            {
                return m_VehicleCreator;
            }
        }
        public Dictionary<string, Vehicle> GarageVehicles
        {
            get
            {
                return m_VehiclesInGarage;
            }
        }
        public void InflateToMax(string i_LicensePlate)
        {
            GarageVehicles[i_LicensePlate].InflateTireToMax();
            GarageVehicles[i_LicensePlate].CurrentWheelsAirPressure = GarageVehicles[i_LicensePlate].ManufactureMaxWheelAirPressure();
        }
        public Vehicle CreateNewVehicle(string i_VehicleChoise)
        {
            return VehicleCreator.CreateVehicle(i_VehicleChoise);
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
        public void InsertToStorage(string i_LicencePlate, ref Vehicle i_VehicleToAdd)
        {
            m_VehiclesInGarage.Add(i_LicencePlate, i_VehicleToAdd);
        }
        public bool VehicleAlreadyInGarage(string i_LicensePlate)
        {
            return GarageVehicles.ContainsKey(i_LicensePlate);
        }
        public void SetVehicleStatus(string i_LicensePlate, eVehicleStatus i_NewStatus)
        {
            GarageVehicles[i_LicensePlate].CarStatus = i_NewStatus;
        }
        public void ChargeVehicleInGarage(string i_LicensePlate, int i_ChargingTime)
        {

            GarageVehicles[i_LicensePlate].ChargeVehicle(i_ChargingTime);
        }
        public void FuelVehicleInGarage(string i_LicensePlate, int i_AmmountToAdd, eEnergyType i_EnergyType)
        {

            GarageVehicles[i_LicensePlate].FuelVehicle(i_AmmountToAdd, i_EnergyType);
        }
    }
}
