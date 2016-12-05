using System.Collections.Generic;
using CallCenter.App.Entities;

namespace CallCenter.App.Data.Repository
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetAllCustomers();
    }
}