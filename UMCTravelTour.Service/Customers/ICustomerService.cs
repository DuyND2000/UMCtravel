using UMCTravelTour.Service.BaseEntities;
using UMCTravelTour.ViewModel.Customers;
using UMCTravelTour.ViewModel.Pages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UMCTravelTour.Service.Customers
{
    public interface ICustomerService
    {
        Task<ResponseResult<CustomerVm>> AddAsync(CustomerVm customerVm);
        Task<ResponseResult<CustomerVm>> DeleteAsync(int id);
        Task<IEnumerable<CustomerVm>> GetAllAsync();      
        Task<CustomerVm> GetByIdAsync(int id);
        Task<ResponseResult<CustomerVm>> UpdateAsync(CustomerVm customerVm);
        public PagedVm<CustomerVm> GetPaging(FilterPaging filterPaging);
        public IEnumerable<CustomerVm> GetAll();
        public CustomerVm GetById(int id);
        public Task<CustomerVm> GetByUserNameAsync(string userName);
        public CustomerVm GetByPhoneAndEmail(string phone, string email);
        public bool CheckPhoneExisted(string phone);
        public bool CheckEmailExisted(string email);
    }
}