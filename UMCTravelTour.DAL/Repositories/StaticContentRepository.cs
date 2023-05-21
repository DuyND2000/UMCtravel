using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMCTravelTour.DAL.Infrastructures;
using UMCTravelTour.Core.Models;
using UMCTravelTour.Core;
using UMCTravelTour.DAL.IRepositories;

namespace UMCTravelTour.DAL.Repositories
{
    public class StaticContentRepository : GenericRepository<StaticContent>, IStaticContentRepository
    {
        public StaticContentRepository(UMCTravelContext context) : base(context)
        {

        }
    }
}
