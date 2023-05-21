using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMCTravelTour.Core.Models
{
    public class TourRestaurantMapping
    {
        public int TourId { get; set; }
        public int RestaurantId { get; set; }

        public virtual Tour Tour { get; set; }
        public virtual Restaurant Restaurant { get; set; }
    }
}
