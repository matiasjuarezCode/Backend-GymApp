using Microsoft.EntityFrameworkCore;
using ProjectGym.Domain.Entities;
using ProjectGym.Domain.Repository;
using ProjectGym.Infraestructure.Repository;
using ProjectGym.Service.Inferface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectGym.Infraestructure;

namespace ProjectGym.Service.Implementation
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IRepository<Employee> _employeRepository;

        public EmployeeRepository(IRepository<Employee> repositoryEmployee)
        {
            _employeRepository = repositoryEmployee;
        }

   
        public async Task Insert(Employee entity)
        {
            var newEmployee = new Employee()
            {
                Legacy = entity.Legacy,
                LastName = entity.LastName,
                FirstName = entity.FirstName,
                Adress = entity.Adress,
                Phone = entity.Phone,
                Username = entity.Username, 
                Password = entity.Password,

            };

            await _employeRepository.Create(newEmployee);
          
        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
            var employeeAll =
                await _employeRepository.GetAll(null,null,false);

                
                return employeeAll.Select(x => new Employee()
                {
                    Id = x.Id,
                    Legacy = x.Legacy,
                    LastName = x.LastName,
                    FirstName = x.FirstName,
                    Adress = x.Adress,
                    Phone = x.Phone,
                    Username = x.Username,
                    Password = x.Password,
                    IsDelete = x.IsDelete
                });
        }

        public async Task Delete(Employee entity)
        {
            await _employeRepository.Delete(entity);
        }


        //public async Task<Employee> GetByFilter(string filter)
        //{
        //    return await _employeRepository.GetByFilter(filter,null,null,true);
        //}

        public async Task<Employee> GetById(long id)
        {
            return await _employeRepository.GetById(id);
        }

        public async Task Update(Employee entity)
        {
            await _employeRepository.Update(entity);

        }
    }
}
