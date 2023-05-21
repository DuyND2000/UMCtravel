using Microsoft.AspNetCore.Identity;

namespace UMCTravelTour.Core.CustomIdentity
{
    public class DreamTourUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
