using ProjectGym.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectGym.Service.Inferface
{
    public interface IEmployeeRepository
    {
        Task Insert(Employee entity);
        Task Update(Employee entity);
        Task Delete(Employee entity);

        Task<Employee> GetById(long id);
        Task<IEnumerable<Employee>> GetAll();
       // Task<Employee> GetByFilter(string filter);

    }
}
