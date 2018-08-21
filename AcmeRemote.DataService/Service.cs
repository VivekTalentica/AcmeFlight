using AcmeRemote.BusinessEntity;
using AcmeRemote.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeRemote.DataService
{
    public class Service : IService
    {
        private IHelicopterRepository _helicopterRepository;
        private IFlightRepository _flightRepository;
        private ICityRepository _cityRepository;
        public Service(IHelicopterRepository helicopterRepository, IFlightRepository flightRepository, ICityRepository cityRepository)
        {
            _helicopterRepository = helicopterRepository;
            _flightRepository = flightRepository;
            _cityRepository = cityRepository;
        }

        public List<Flight> GetAllFlights()
        {
            return _flightRepository.Get();
        }
        public Flight GetFlightById(int id)
        {
            return _flightRepository.GetById(id);
        }

        public void SaveFlightsDefaults()
        {
            _flightRepository.SaveDefaults();
        }
        public List<Flight> GetFlights(DateTime startDate, DateTime endDate)
        {
            return _flightRepository.GetFlights(startDate, endDate);
        }
        public List<City> GetAllCities()
        {
            return _cityRepository.Get();
        }
        public City GetCityById(int id)
        {
            return _cityRepository.GetById(id);
        }

        public Helicopter GetHelicopterById(int id)
        {
            return _helicopterRepository.GetById(id);
        }
        public List<Helicopter> GetAllHelicopter()
        {
            return _helicopterRepository.Get();
        }
    }
}
