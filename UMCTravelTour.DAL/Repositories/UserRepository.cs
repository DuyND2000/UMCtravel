using Microsoft.AspNetCore.Identity;
using UMCTravelTour.Core;
using UMCTravelTour.Core.CustomIdentity;
using UMCTravelTour.DAL.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMCTravelTour.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UMCTravelContext _context;

        public UserRepository(UMCTravelContext context)
        {
            _context = context;
        }

        public void AddUser(IdentityUser user)
        {
            _context.Users.Add(user);
        }

        public void DeleteUser(string id)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);
            _context.Users.Remove(user);
        }

        public IdentityUser GetUser(string id)
        {
            return _context.Users.FirstOrDefault(u => u.Id.Equals(id));
        }

        public ICollection<IdentityUser> GetUsers()
        {
           return _context.Users.Where(u => u.Email != "admin@umctravel.com").ToList();
        }

        public ICollection<IdentityUser> GetUsersByRole(string roleName)
        {
            var role = _context.Roles.FirstOrDefault(r => r.Name == roleName);
            var userIds = _context.UserRoles.Where(ur => ur.RoleId == role.Id).Select(ur => ur.UserId);

            return _context.Users.Where(u => userIds.Contains(u.Id)).ToList();
        }

        public void UpdateUser(IdentityUser user)
        {
            _context.Users.Update(user);
        }
    }
}
