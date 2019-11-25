using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectGym.Domain.Entities;
using ProjectGym.Infraestructure;
using ProjectGym.Service.Interface;

namespace ProjectGym.Application.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly DataContext _dataContext;

        public ProductController(IProductRepository productRepository, DataContext dataContext)
        {
            _productRepository = productRepository;
            _dataContext = dataContext;
        }

        [HttpGet]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> Get()
        {
            var products = await _productRepository.GetAll();
            return Ok(products.Where(x=>!x.IsDelete));
        }

        // GET: api/Product/5
        [HttpGet("{id}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productRepository.GetById(id);
            if (product != null)
            {
                return Ok(product);
            }
            else
            {
                return Ok("Product NotExist");
            }

        }
      

        // POST: api/Employee
        [HttpPost]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> Insert(Product product)
        {
            if (await ExistCode(product.Code))
            {
                return Ok("Producto con Codigo Ya Existente");
            }
            else
            {
                
                await _productRepository.Insert(product);
                return Ok(product);
            }

        }

        private async Task<bool> ExistCode(int code)
        {
            var products = await _productRepository.GetAll();

            return products.Any(x => x.Code == code);
        }

        [HttpPut("{id}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> Put(Product product, int id)
        {
            var _product = await _productRepository.GetById(id);

            if (_product != null)
            {
                if(_product.Code != product.Code)
                {
                    if (await ExistCode(product.Code))
                    {
                        return Ok("Producto con Codigo Ya Existente");
                    }
                    else
                    {
                        _product.Code = product.Code;
                        _product.Description = product.Description;
                        _product.CostPrice = product.CostPrice;
                        _product.SalePrice = product.SalePrice;
                        _product.Stock = product.Stock;
                        _product.DiscountStock = product.DiscountStock;
                        _product.NegativeStock = product.NegativeStock;

                        await _productRepository.Update(_product);
                        return Ok(_product);
                    }
                }
                else
                {
                    _product.Code = product.Code;
                    _product.Description = product.Description;
                    _product.CostPrice = product.CostPrice;
                    _product.SalePrice = product.SalePrice;
                    _product.Stock = product.Stock;
                    _product.DiscountStock = product.DiscountStock;
                    _product.NegativeStock = product.NegativeStock;

                    await _productRepository.Update(_product);
                    return Ok(_product);
                }            
            }
            else
            {
                return Ok("Product NotExist");
            }


        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> Delete(int id)
        {
            var productDelete = await _productRepository.GetById(id);
            if (productDelete != null)
            {
                await _productRepository.Delete(productDelete);
                return Ok(productDelete);

            }
            else
            {
                return Ok("Product NotExist");
            }



        }
    }
}