using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ProjectGym.Domain.Entities;
using ProjectGym.Domain.Repository;
using ProjectGym.Infraestructure;
using ProjectGym.Service.Interface;

namespace ProjectGym.Service.Implementation
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IRepository<Customer> _customerRepository;

        public CustomerRepository(IRepository<Customer> customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public async Task Delete(Customer entity)
        {
            await _customerRepository.Delete(entity);
        }

        public async Task<IEnumerable<Customer>> GetAll()
        {
            var customerAll =
                await _customerRepository.GetAll(null, null, false);

            return customerAll;

        }

        public async Task<Customer> GetById(long id)
        {
            return await _customerRepository.GetById(id);
        }

        public async Task Insert(Customer entity)
        {
            await _customerRepository.Create(entity);
        }

        public async Task Update(Customer entity)
        {
            await _customerRepository.Update(entity);
        }
    }
}
