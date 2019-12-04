using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectGym.Domain.Entities;
using ProjectGym.Infraestructure;
using ProjectGym.Service.Interface;

namespace ProjectGym.Application.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomersController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        // GET: api/Customers
        [HttpGet]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> Get()
        {
            var customers = await _customerRepository.GetAll();
            return Ok(customers.Where(x => !x.IsDelete));
        }

        // GET: api/Customers/5
        [HttpGet("{id}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> GetById(long id)
        {
            var customer = await _customerRepository.GetById(id);

            if (customer == null)
            {
                return Ok("No Existe");
            }

            return Ok(customer);
        }

        // PUT: api/Customers/5
        [HttpPut("{id}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> Put(Customer customer, long id)
        {
            var _customer = await _customerRepository.GetById(id);

            if(_customer == null)
            {
                return Ok("No Existe");
            }
            else
            {
                _customer.Id = id;
                _customer.MembershipNumber = customer.MembershipNumber;
                _customer.LastName = customer.LastName;
                _customer.FirstName = customer.FirstName;
                _customer.Adress = customer.Adress;
                _customer.Phone = customer.Phone;
                _customer.DateAdmission = customer.DateAdmission;

                await _customerRepository.Update(_customer);
                return Ok(_customer);
            }           
        }

        // POST: api/Customers
        [HttpPost]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> Post(Customer customer)
        {
            if(await VerifyExistsLastNameAsync(customer.LastName))
            {
                return Ok("Ya Existe Cliente");
            }
            else
            {
                await _customerRepository.Insert(customer);
                return Ok(customer);
            }
        }

        private async Task<bool> VerifyExistsLastNameAsync(string lastName)
        {
            var customers = await _customerRepository.GetAll();
            return customers.Any(x => x.LastName.ToLower() == lastName.ToLower());
            
        }

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> Delete(long id)
        {
            var customerDelete = await _customerRepository.GetById(id);
            if(customerDelete != null)
            {
                await _customerRepository.Delete(customerDelete);
                return Ok(customerDelete);
            }
            else
            {
                return Ok("No Existe");
            }
        }

        
    }
}
