using CallCenter.App.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CallCenter.App.Data.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private CallCenterContext _context;

        public CustomerRepository(CallCenterContext context)
        {
            _context = context;
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return _context.Customers.ToList();
        }
    }
}
