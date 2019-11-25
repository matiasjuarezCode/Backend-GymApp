using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ProjectGym.Domain.Entities;

namespace ProjectGym.Service.Interface
{
    public interface ICustomerRepository
    {
        Task Insert(Customer entity);
        Task Update(Customer entity);
        Task Delete(Customer entity);

        Task<Customer> GetById(long id);
        Task<IEnumerable<Customer>> GetAll();
    }
}
