﻿using AcmeRemote.BusinessEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeRemote.DataAccess
{
    public class HelicopterRepository: BaseRepository<Helicopter>, IHelicopterRepository
    {
        public HelicopterRepository(): base("helicopter.json")
        {

        }
    }
}
