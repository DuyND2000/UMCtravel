using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMCTravelTour.Common.Constants
{
    public static class ImageFolderSystem
    {
        public static string HotelImageFolder(int hotelId)
        {
            return $"Hotel/{hotelId}";
        }

        public static string LocationImageFolder(int locationId)
        {
            return $"Location/{locationId}";
        }

        public static string RestaurantImageFolder(int restaurantId)
        {
            return $"Restaurant/{restaurantId}";
        }

        public static string RoomImageFolder(int hotelId, int roomId)
        {
            return $"Hotel/{hotelId}/Room/{roomId}";
        }

        public static string TourImageFolder(int tourId)
        {
            return $"Tour/{tourId}";
        }
    }
}
