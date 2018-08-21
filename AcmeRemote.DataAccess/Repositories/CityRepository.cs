using AcmeRemote.BusinessEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeRemote.DataAccess
{
    public class CityRepository: BaseRepository<City>, ICityRepository
    {
        public CityRepository(): base("city.json")
        {

        }
    }
}
