using Microsoft.AspNetCore.Identity;
using UMCTravelTour.Core.CustomIdentity;
using System.Collections.Generic;

namespace UMCTravelTour.DAL.IRepositories
{
    public interface IUserRepository
    {
        ICollection<IdentityUser> GetUsers();
        ICollection<IdentityUser> GetUsersByRole(string roleName);
        IdentityUser GetUser(string id);

        void AddUser(IdentityUser user);
        void UpdateUser(IdentityUser user);
        void DeleteUser(string id);
    }
}