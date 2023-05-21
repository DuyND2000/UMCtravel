using AutoMapper;
using Microsoft.AspNetCore.Identity;
using UMCTravelTour.Common.Constants;
using UMCTravelTour.Core.CustomIdentity;
using UMCTravelTour.Core.Models;
using UMCTravelTour.DAL.Infrastructures;
using UMCTravelTour.DAL.IRepositories;
using UMCTravelTour.Service.BaseEntities;
using UMCTravelTour.ViewModel.Customers;
using UMCTravelTour.ViewModel.Locations;
using UMCTravelTour.ViewModel.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMCTravelTour.Service.Customers
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly UserManager<DreamTourUser> _userManager;
        private readonly SignInManager<DreamTourUser> _signInManager;

        public CustomerService(IUnitOfWork unitOfWork, IMapper mapper, UserManager<DreamTourUser> userManager, SignInManager<DreamTourUser> signInManager)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task<ResponseResult<CustomerVm>> AddAsync(CustomerVm customerVm)
        {
            try
            {
                var customer = _mapper.Map<Customer>(customerVm);
                _unitOfWork.CustomerRepository.Add(customer);
                await _unitOfWork.SaveChangesAsync();
                return new ResponseResult<CustomerVm>();
            }
            catch (Exception ex)
            {
                return new ResponseResult<CustomerVm>(ex.Message);
            }
        }

        public async Task<ResponseResult<CustomerVm>> DeleteAsync(int id)
        {
            try
            {
                _unitOfWork.CustomerRepository.Delete(id);
                await _unitOfWork.SaveChangesAsync();
                return new ResponseResult<CustomerVm>();
            }
            catch (Exception ex)
            {
                return new ResponseResult<CustomerVm>(ex.Message);
            }
        }

        public async Task<IEnumerable<CustomerVm>> GetAllAsync()
        {
            var customers = await _unitOfWork.CustomerRepository.GetAllAsync();
            var customerVm = _mapper.Map<IEnumerable<CustomerVm>>(customers);
            return customerVm;
        }

        public async Task<CustomerVm> GetByIdAsync(int id)
        {
            var customer = await _unitOfWork.CustomerRepository.GetByIdAsync(id);
            var customerVm = _mapper.Map<CustomerVm>(customer);
            return customerVm;
        }
        public CustomerVm GetById(int id)
        {
            var customer = _unitOfWork.CustomerRepository.GetById(id);
            var customerVm = _mapper.Map<CustomerVm>(customer);
            return customerVm;
        }

        public async Task<ResponseResult<CustomerVm>> UpdateAsync(CustomerVm customerVm)
        {
            try
            {
                var customer = _mapper.Map<Customer>(customerVm);
                _unitOfWork.CustomerRepository.Update(customer);
                await _unitOfWork.SaveChangesAsync();
                return new ResponseResult<CustomerVm>();
            }
            catch (Exception ex)
            {
                return new ResponseResult<CustomerVm>(ex.Message);
            }
        }
        public PagedVm<CustomerVm> GetPaging(FilterPaging filterPaging)
        {
            Func<IEnumerable<Customer>, IOrderedEnumerable<Customer>> predicate = null;
            if (filterPaging.TypeOfSort == Constant.Sort.ASC)
            {
                if (filterPaging.SortBy == Constant.SortBy.Name)
                {
                    predicate = x => x.OrderBy(x => x.CustomerName);
                }
                else
                {
                    predicate = x => x.OrderBy(x => x.LastModifiedOn);
                }
            }
            else
            {
                if (filterPaging.SortBy == Constant.SortBy.Name)
                {
                    predicate = x => x.OrderByDescending(x => x.CustomerName);
                }
                else
                {
                    predicate = x => x.OrderByDescending(x => x.LastModifiedOn);
                }
            }
            Func<Customer, bool> filter = null;
            if (!string.IsNullOrEmpty(filterPaging.Keyword))
            {
                filter = x => x.CustomerName.ToLower().Contains(filterPaging.Keyword.ToLower());
            }
            PagedVm<Customer> customers = _unitOfWork.CustomerRepository.GetPaging(null, filter, predicate, filterPaging.PageSize, filterPaging.PageIndex);
            IEnumerable<CustomerVm> customerVms = this._mapper.Map<IEnumerable<CustomerVm>>(customers.Data.AsEnumerable());
            return new PagedVm<CustomerVm>(customerVms, filterPaging.PageIndex, filterPaging.PageSize, customers.TotalPage);
        }
        public IEnumerable<CustomerVm> GetAll()
        {
            var customers = _unitOfWork.CustomerRepository.GetAll();
            var customerVms = _mapper.Map<IEnumerable<CustomerVm>>(customers);
            return customerVms;
        }

        public async Task<CustomerVm> GetByUserNameAsync(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            var customer = _unitOfWork.CustomerRepository.GetAll().FirstOrDefault(c =>
                c.Email == user.Email && c.Phone == user.PhoneNumber
            );

            var customerVm = _mapper.Map<CustomerVm>(customer);
            return customerVm;
        }
        public CustomerVm GetByPhoneAndEmail(string phone, string email)
        {
            var customer = _unitOfWork.CustomerRepository.GetByPhoneAndEmail(phone,email);
            var customerVm = _mapper.Map<CustomerVm>(customer);
            return customerVm;
        }

        public bool CheckPhoneExisted(string phone)
        {
            return _unitOfWork.CustomerRepository.CheckPhoneExisted(phone);
        }

        public bool CheckEmailExisted(string email)
        {
            return _unitOfWork.CustomerRepository.CheckEmailExisted(email);
        }
    }
}
