using UMCTravelTour.Service.BaseEntities;
using UMCTravelTour.ViewModel.Pages;
using UMCTravelTour.ViewModel.Tours;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMCTravelTour.Service.Tours
{
    public interface ITourService
    {
        public PagedVm<TourVm> GetPaging(FilterPaging filterPaging);
        public Task<IEnumerable<TourVm>> GetAllAsync();
        public Task<ResponseResult<TourVm>> AddAsync(TourVm tourVm);
        public Task<ResponseResult<TourVm>> UpdateAsync(TourVm tourVm);
        public Task<ResponseResult<TourVm>> DeleteAsync(int id);
        public Task<TourVm> GetByIdAsync(int id);
        public IEnumerable<TourVm> GetAll();
        public TourVm GetById(int id);
        public double GetPriceByTourId(int id);
        public Task<IEnumerable<TourVm>> GetTourActiveAsync();
        public Task<IEnumerable<TourVm>> GetRelateToursAsync(int tourId);
    }
}
