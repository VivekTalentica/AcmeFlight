using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeRemote.BusinessEntity
{
    public class Flight: BaseEntity
    {
        public string FlightNumber {
            get
            {
                return FlightTime.ToString() + "-" + DestinationId + "-" + SourceId;
            }
        }
        public List<int> BookedSeats { get; set; }
        public int HelicopterId { get; set; }
        public int DestinationId { get; set; }
        public int SourceId { get; set; }
        public DateTime FlightTime { get; set; }
        public int Duration { get; set; }
    }
}
