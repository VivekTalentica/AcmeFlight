using AcmeRemote.BusinessEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AcmeRemoteFlight.Models
{
    public class FlightResponse
    {
        public FlightResponse()
        {
            BookedSeats = new List<int>();
        }
        public string FlightNumber { get; set; }
        public List<int> BookedSeats { get; set; }

        public int Capacity { get; set; }
        public int Available
        {
            get
            {
                return Capacity - BookedSeats.Count;
            }
        }

        public City Destination { get; set; }
        public City Source { get; set; }
    }
}