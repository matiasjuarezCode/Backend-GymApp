using ProjectGym.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGym.Service.Interface
{
    public interface IInscriptionRepository
    {

        Task Insert(Inscription entity);
        Task Update(Inscription entity);
        Task Delete(Inscription entity);

        Task<Inscription> GetById(long id);
        Task<IEnumerable<Inscription>> GetAll();
    }
}
