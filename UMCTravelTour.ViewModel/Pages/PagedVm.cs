using System.Collections.Generic;

namespace UMCTravelTour.ViewModel.Pages
{
    public class PagedVm<T> where T : class
    {
        public PagedVm(IEnumerable<T> data, int pageIndex, int pageSize, int totalPage)
        {
            this.Data = data;
            this.PageIndex = pageIndex;
            this.PageSize = pageSize;
            this.TotalPage = totalPage;
        }

        public IEnumerable<T> Data { get; set; }

        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public int TotalPage { get; set; }
    }
}