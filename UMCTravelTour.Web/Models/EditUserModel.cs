using Microsoft.AspNetCore.Identity;
using UMCTravelTour.Core.CustomIdentity;
using System.Collections.Generic;

namespace UMCTravelTour.Web.Models
{
    public class EditUserModel
    {
        public DreamTourUser User { get; set; }
        public string Role { get; set; }
    }
}
