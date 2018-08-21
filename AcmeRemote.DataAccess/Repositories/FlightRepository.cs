using AcmeRemote.BusinessEntity;
using AcmeRemote.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace AcmeRemote.DataAccess
{
    public class FlightRepository: BaseRepository<Flight>, IFlightRepository
    {
        public FlightRepository(): base("flights.json")
        {

        }

        public List<Flight> GetFlights(DateTime startDate, DateTime endDate)
        {
            if (_entities == null)
            {
                FillEntities();
            }
            return _entities.Where(e => e.FlightTime >= startDate && e.FlightTime <= endDate).ToList();
        }

        public void SaveDefaults()
        {
            var defaultFlights = new List<Flight>();
            var startDate = DateTime.Now;
            var endDate = startDate.AddYears(1);
            while(startDate < endDate)
            {
                var def1 = DefaultHelicopter1(startDate);
                var def2 = DefaultHelicopter2(startDate);
                var def3 = DefaultHelicopter3(startDate);

                if(startDate.Day % 6 == 0)
                {
                    def1.BookedSeats = new List<int> { };
                    def2.BookedSeats = new List<int> { };
                    def3.BookedSeats = new List<int> { };
                }
                else if (startDate.Day % 4 == 0)
                {
                    def1.BookedSeats = new List<int> { 11, 12, 21, 22, 31, 32 };
                    def2.BookedSeats = new List<int> { 11, 12 };
                    def3.BookedSeats = new List<int> { };
                }
                else if (startDate.Day % 3 == 0)
                {
                    def1.BookedSeats = new List<int> { 11, 12, 21, 22};
                    def2.BookedSeats = new List<int> { 11, 12 };
                    def3.BookedSeats = new List<int> { 11, 12 };
                }
                else if (startDate.Day % 2 == 0)
                {
                    def1.BookedSeats = new List<int> { 11, 12, 21, 22 };
                    def2.BookedSeats = new List<int> { 11, 12, 21, 22 };
                    def3.BookedSeats = new List<int> { 11 };
                }
                else
                {
                    def1.BookedSeats = new List<int> { 11, 12, 21, 22, 31, 32 };
                    def2.BookedSeats = new List<int> { 11, 12, 21, 22 };
                    def3.BookedSeats = new List<int> { 11, 12 };
                }
                defaultFlights.Add(def1);
                defaultFlights.Add(def2);
                defaultFlights.Add(def3);
                startDate = startDate.AddDays(1);
            }
            
            Utility.SaveFile("flights.json", defaultFlights);

        }


        // This is only for Demo. actually flight details are stored in a database.
        private Flight DefaultHelicopter1(DateTime date)
        {
            var flight = new Flight();
            flight.BookedSeats = new List<int>();
            flight.DestinationId = 2;
            flight.SourceId = 1;
            flight.HelicopterId = 1;
            flight.FlightTime = date.Date.AddHours(5);
            flight.Duration = 180;
            return flight;
        }
        private Flight DefaultHelicopter2(DateTime date)
        {
            var flight = new Flight();
            flight.BookedSeats = new List<int>();
            flight.DestinationId = 3;
            flight.SourceId = 1;
            flight.HelicopterId = 2;
            flight.FlightTime = date.Date.AddHours(7);
            flight.Duration = 30;
            return flight;
        }
        private Flight DefaultHelicopter3(DateTime date)
        {
            var flight = new Flight();
            flight.BookedSeats = new List<int>();
            flight.DestinationId = 4;
            flight.SourceId = 1;
            flight.HelicopterId = 3;
            flight.FlightTime = date.Date.AddHours(7);
            flight.Duration = 30;
            return flight;
        }
    }
}
