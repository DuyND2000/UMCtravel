using Microsoft.AspNetCore.Identity;
using UMCTravelTour.Core;
using UMCTravelTour.DAL.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMCTravelTour.DAL.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly UMCTravelContext _context;

        public RoleRepository(UMCTravelContext context)
        {
            _context = context;
        }

        public ICollection<IdentityRole> GetRoles()
        {
            return _context.Roles.ToList();
        }
    }
}
