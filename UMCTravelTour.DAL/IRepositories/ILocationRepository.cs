﻿using UMCTravelTour.Core.Models;
using UMCTravelTour.DAL.Infrastructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMCTravelTour.DAL.IRepositories
{
    public interface ILocationRepository : IGenericRepository<Location>
    {
        public Location GetLocationHR(int locationId);
    }
}
