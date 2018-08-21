using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeRemote.BusinessEntity
{
    public class Helicopter: BaseEntity
    {
        public string ModelNumber { get; set; }
        public string Manufacture { get; set; }
        public int Rows { get; set; }
        public int Column { get; set; }
        public int Capacity
        {
            get
            {
                return Rows * Column;
            }
        }
    }
}
