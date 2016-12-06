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

        public void Add(Customer customer)
        {
            _context.Add(customer);
        }

        public void Delete(Customer customer)
        {
            _context.Remove(customer);
        }

        public IEnumerable<Customer> GetAll()
        {
            return _context.Customers.ToList();
        }

        public Customer Find(int id)
        {
            return _context.Customers.Single(t => t.Id == id);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public void Update(Customer customer)
        {
            _context.Customers.Update(customer);
        }
    }
}
