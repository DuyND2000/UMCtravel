using UMCTravelTour.ViewModel.Comments;
using UMCTravelTour.ViewModel.Customers;
using System.Collections.Generic;

namespace UMCTravelTour.Web.ViewModels
{
    public class CustomerCommentTour
    {
        public int TourId { get; set; }
        public CustomerVm CurrentUser { get; set; }
        // All comments in a tour
        public List<CustomerComment> CustomerComments { get; set; }

        public bool AllowComment { get; set; }

        public int NumberOfComment { get; set; } = 5;
    }
}
