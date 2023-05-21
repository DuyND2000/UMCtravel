using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UMCTravelTour.Common.Constants;
using UMCTravelTour.Core.CustomIdentity;
using UMCTravelTour.Service.Bookings;
using UMCTravelTour.Service.Comments;
using UMCTravelTour.Service.Customers;
using UMCTravelTour.ViewModel.Bookings;
using UMCTravelTour.ViewModel.Customers;
using UMCTravelTour.Web.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UMCTravelTour.Web.ViewComponents.CommentComponent
{
    public class CommentComponent : ViewComponent
    {
        private readonly ICommentService _commentService;
        private readonly ICustomerService _customerService;
        private readonly IBookingService _bookingService;
        private readonly UserManager<DreamTourUser> _userManager;

        public CommentComponent(ICommentService commentService, ICustomerService customerService,
            UserManager<DreamTourUser> userManager, IBookingService bookingService)
        {
            _commentService = commentService;
            _customerService = customerService;
            _userManager = userManager;
            _bookingService = bookingService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int tourId, int showComment)
        {
            return await Task.FromResult((IViewComponentResult)View("Default", GetCombineModel(tourId, showComment).Result));
        }

        public async Task<CustomerCommentTour> GetCombineModel(int tourId, int showComment)
        {
            // get thong tin dang login user: user co thong tin customer => customer, neu user khong co thong tin customer => staff
            CustomerVm currentUser = null;
            if (HttpContext.User.Identity.Name != null)
            {
                currentUser = await _customerService.GetByUserNameAsync(HttpContext.User.Identity.Name);
            }
            var customers = _customerService.GetAll();

            // kiem tra duoc phep comment
            var allowComment = false;
            if (currentUser != null)
            {
                var booking = _bookingService.GetAll().FirstOrDefault(b => b.TourId == tourId && b.CustomerId == currentUser.CustomerId);
                if (booking != null && booking.Status == Constant.StatusBooking.Completed)
                {
                    allowComment = true;
                }
            }

            // lay comments theo tourid
            var tourComments = _commentService.GetAll().Where(c => c.TourId == tourId);
            var customerComments = new List<CustomerComment>();
            if (tourComments.Count() > 0)
            {
                foreach (var comment in tourComments)
                {
                    foreach (var customer in customers)
                    {
                        if (comment.CustomerId == customer.CustomerId)
                        {
                            CustomerComment customerComment = new CustomerComment()
                            {
                                CustomerVm = customer,
                                CommentVm = comment
                            };
                            customerComments.Add(customerComment);
                        }
                    }
                }
            }
            else
            {
                return new CustomerCommentTour()
                {
                    TourId = tourId,
                    CurrentUser = currentUser,
                    CustomerComments = null,
                    AllowComment = allowComment
                };
            }

            //day thong tin can su dung vao viewModel
            CustomerCommentTour customerCommentTour = new CustomerCommentTour()
            {
                TourId = tourId,
                CurrentUser = currentUser,
                CustomerComments = customerComments.ToList(),
                AllowComment = allowComment,
                NumberOfComment = showComment
            };

            return customerCommentTour;
        }
    }
}
