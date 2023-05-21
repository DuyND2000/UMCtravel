using UMCTravelTour.Core;
using UMCTravelTour.Core.Models;
using UMCTravelTour.DAL.Infrastructures;
using UMCTravelTour.DAL.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMCTravelTour.DAL.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(UMCTravelContext context) : base(context)
        {
        }

        public bool CheckEmailExisted(string email)
        {
            return DbSet.Any(x => x.Email == email);
        }

        public bool CheckPhoneExisted(string phone)
        {
            return DbSet.Any(x=>x.Phone == phone);
        }

        public Customer GetByPhoneAndEmail(string phone,string email)
        {
            return DbSet.FirstOrDefault(x=>x.Phone == phone && x.Email == email);
        }
      
    }
}
