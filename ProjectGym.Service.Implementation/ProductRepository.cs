using ProjectGym.Domain.Entities;
using ProjectGym.Domain.Repository;
using ProjectGym.Infraestructure;
using ProjectGym.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGym.Service.Implementation
{
    public class ProductRepository : IProductRepository
    {
        private readonly IRepository<Product> _productRepository;

        public ProductRepository(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task Delete(Product entity)
        {
            await _productRepository.Delete(entity);
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            var productosAll =
                await _productRepository.GetAll(null,null,false);

            return productosAll;

        }

        public async Task<Product> GetById(long id)
        {
            return await _productRepository.GetById(id);
        }

        public async Task Insert(Product entity)
        {
            

            await _productRepository.Create(entity);
        }

        public async Task Update(Product entity)
        {
            await _productRepository.Update(entity);
        }
    }
}
