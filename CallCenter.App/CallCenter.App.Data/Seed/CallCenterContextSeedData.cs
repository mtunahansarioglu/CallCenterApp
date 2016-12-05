using CallCenter.App.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CallCenter.App.Data.Seed
{
    public class CallCenterContextSeedData
    {
        private CallCenterContext _context;

        public CallCenterContextSeedData(CallCenterContext context)
        {
            _context = context;
        }

        public async Task EnsureSeedData()
        {
            if(!_context.Customers.Any())
            {
                var customer = new Customer()
                {
                    Name = "Tan",
                    Surname = "Atagoren",
                    Phone = "5333762983",
                    Email = "tan@gmail.com"
                };

                _context.Customers.Add(customer);
                await _context.SaveChangesAsync();
            }
        }
    }
}
