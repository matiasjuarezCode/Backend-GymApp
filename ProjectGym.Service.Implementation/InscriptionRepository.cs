using ProjectGym.Domain.Entities;
using ProjectGym.Domain.Repository;
using ProjectGym.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGym.Service.Implementation
{
    public class InscriptionRepository : IInscriptionRepository
    {
        private readonly IRepository<Inscription> _inscriptionRepository;

        public InscriptionRepository(IRepository<Inscription> inscriptionRepository)
        {
            _inscriptionRepository = inscriptionRepository;
        }
        public async Task Delete(Inscription entity)
        {
            await _inscriptionRepository.Delete(entity);
        }

        public async Task<IEnumerable<Inscription>> GetAll()
        {
            var inscriptionAll = await _inscriptionRepository.GetAll(null, null, false);

            return inscriptionAll;
        }

        public async Task<Inscription> GetById(long id)
        {
            return await _inscriptionRepository.GetById(id);
        }

        public async Task Insert(Inscription entity)
        {
            await _inscriptionRepository.Create(entity);
        }

        public async Task Update(Inscription entity)
        {
            await _inscriptionRepository.Update(entity);
        }
    }
}
