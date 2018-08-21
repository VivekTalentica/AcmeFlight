using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeRemote.BusinessEntity
{
    public class City : BaseEntity
    {
        public string CityName { get; set; }
        public string AirportName { get; set; }
        public string Code { get; }
    }
}
