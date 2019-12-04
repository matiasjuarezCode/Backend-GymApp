using ProjectGym.Domain.Entities;
using ProjectGym.Domain.Repository;
using ProjectGym.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGym.Service.Implementation
{
    public class PlanRepository : IPlanRepository
    {
        private readonly IRepository<Plan> _planRepository;

        public PlanRepository(IRepository<Plan> planRepository)
        {
            _planRepository = planRepository;
        }

        public async Task Delete(Plan entity)
        {
            await _planRepository.Delete(entity);
        }

        public async Task<IEnumerable<Plan>> GetAll()
        {
            var AllPlan = await _planRepository.GetAll(null, null, false);
            return AllPlan;
        }

        public async Task<Plan> GetById(long id)
        {
            return await _planRepository.GetById(id);
        }

        public async Task Insert(Plan entity)
        {
            await _planRepository.Create(entity);
        }

        public async Task Update(Plan entity)
        {
            await _planRepository.Update(entity);
        }
    }
}
