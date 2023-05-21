using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace UMCTravelTour.Core.CustomIdentity
{
    public class DreamTourRole : IdentityRole
    {
        [Column(TypeName = "ntext")]
        public string Description { get; set; }
    }
}
