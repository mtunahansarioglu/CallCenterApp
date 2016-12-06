using AutoMapper;
using CallCenter.App.Data;
using CallCenter.App.Data.Repository;
using CallCenter.App.Entities;
using CallCenter.App.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CallCenter.App.WebApi.Controllers
{
    [Route("api/customer")]
    public class CustomerController : Controller
    {
        private ICustomerRepository _repository;

        public CustomerController(ICustomerRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("")]
        public IActionResult Get()
        {
            try
            {
                var results = _repository.GetAll();
                return Ok(Mapper.Map<IEnumerable<CustomerViewModel>>(results));

            }
            catch (Exception ex)
            {
                return BadRequest("Error Occured");
            }
        }

        [HttpGet("{id}", Name = "GetTodo")]
        public IActionResult GetById(int id)
        {
            var existingCustomer = _repository.Find(id);
            if (existingCustomer == null)
            {
                return NotFound();
            }
            return Created($"api/customer/GetCustomer", Mapper.Map<CustomerViewModel>(existingCustomer));
        }

        [HttpPost("")]
        public async Task<IActionResult> Post([FromBody]CustomerViewModel customerModel)
        {
            if (ModelState.IsValid)
            {
                //Save To Db
                var newCustomer = Mapper.Map<Customer>(customerModel);

                _repository.Add(newCustomer);

                if (await _repository.SaveChangesAsync())
                {
                    return Created($"api/customer/{customerModel.Name}", Mapper.Map<CustomerViewModel>(newCustomer));
                }
            }
            return BadRequest("Failed To Save the customer");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody]CustomerViewModel customerModel)
        {
            if (ModelState.IsValid)
            {
                Customer existingCustomer = _repository.Find(id);

                existingCustomer.Name = customerModel.Name;
                //Customer customer = Mapper.Map<Customer>(customerModel);
                //customer.Id = id;
                _repository.Update(existingCustomer);
                if (await _repository.SaveChangesAsync())
                {
                    return new NoContentResult();
                }
            }
            return BadRequest("Failed To Update Customer");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingCustomer = _repository.Find(id);
            if (existingCustomer == null)
            {
                return NotFound();
            }

            _repository.Delete(existingCustomer);
            if (await _repository.SaveChangesAsync())
            {
                return new NoContentResult();
            }
            return BadRequest();
        }
    }
}
