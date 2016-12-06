using System.Collections.Generic;
using CallCenter.App.Entities;
using System.Threading.Tasks;

namespace CallCenter.App.Data.Repository
{
    public interface ICustomerRepository
    {
        void Add(Customer customer);
        IEnumerable<Customer> GetAll();
        Customer Find(int id);
        void Update(Customer customer);
        void Delete(Customer customer);
        Task<bool> SaveChangesAsync();
    }
}