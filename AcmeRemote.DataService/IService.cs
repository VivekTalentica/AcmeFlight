using System;
using System.Collections.Generic;
using AcmeRemote.BusinessEntity;

namespace AcmeRemote.DataService
{
    public interface IService
    {
        List<City> GetAllCities();
        List<Flight> GetAllFlights();
        List<Helicopter> GetAllHelicopter();
        void SaveFlightsDefaults();
        City GetCityById(int id);
        Flight GetFlightById(int id);
        List<Flight> GetFlights(DateTime startDate, DateTime endDate);
        Helicopter GetHelicopterById(int id);
    }
}