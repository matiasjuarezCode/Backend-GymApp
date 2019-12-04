using ProjectGym.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGym.Service.Interface
{
    public interface IPlanRepository
    {
        Task Insert(Plan entity);
        Task Update(Plan entity);
        Task Delete(Plan entity);

        Task<Plan> GetById(long id);
        Task<IEnumerable<Plan>> GetAll();
    }
}
