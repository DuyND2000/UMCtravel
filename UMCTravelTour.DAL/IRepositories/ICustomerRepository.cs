using UMCTravelTour.Core.Models;
using UMCTravelTour.DAL.Infrastructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMCTravelTour.DAL.IRepositories
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
        public Customer GetByPhoneAndEmail(string phone, string email);
        public bool CheckPhoneExisted(string phone);
        public bool CheckEmailExisted(string email);
    }
}
