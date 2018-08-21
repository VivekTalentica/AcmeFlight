using AcmeRemote.BusinessEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeRemote.DataAccess
{
    public interface IFlightRepository: IBaseRepository<Flight>
    {
        List<Flight> GetFlights(DateTime startDate, DateTime endDate);
        void SaveDefaults();
    }
}
