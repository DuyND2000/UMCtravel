using UMCTravelTour.Common.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMCTravelTour.ViewModel.Pages
{
    public class FilterPaging
    {
        public string Keyword { get; set; } = "";

        public int PageSize { get; set; } = Constant.PageSize;

        public int PageIndex { get; set; } = 1;

        public string TypeOfSort { get; set; } = "ASC";

        public string SortBy { get; set; } = Constant.SortBy.ModifiedOn;
        public string TypeOfData { get; set; } = null;

    }
}
