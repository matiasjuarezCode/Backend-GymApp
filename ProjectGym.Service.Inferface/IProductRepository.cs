using ProjectGym.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGym.Service.Interface
{
    public interface IProductRepository
    {
        Task Insert(Product entity);
        Task Update(Product entity);
        Task Delete(Product entity);

        Task<Product> GetById(long id);
        Task<IEnumerable<Product>> GetAll();

    }
}
