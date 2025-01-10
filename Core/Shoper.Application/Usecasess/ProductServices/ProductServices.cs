using Shoper.Application.Dtos.ProductDtos;
using Shoper.Application.Interfaces;
using Shoper.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoper.Application.Usecasess.ProductServices
{
    public class ProductServices : IProductServices
    {
        private readonly IRepository<Product> _productRepository;

        public ProductServices(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task CreateProductAsync(CreateProductDto createProductDto)
        {
            await _productRepository.CreateAsync(new Product
            {
                ProductName = createProductDto.ProductName,
                Description = createProductDto.Description,
                Price = createProductDto.Price,
                Stock = createProductDto.Stock,
                ImageUrl = createProductDto.ImageUrl,
                CategoryId = createProductDto.CategoryId
            });
           
        }

        public async Task DeleteProductAsync(int id)
        {
            var values = await _productRepository.GetByIdAsync(id);
            await _productRepository.DeleteAsync(values);
        }

        public async Task<List<ResultProductDto>> GetAllProductAsync()
        {
            var products = await _productRepository.GetAllAsync();
            return products.Select(x => new ResultProductDto
            {
                ProductId = x.ProductId,
                ProductName = x.ProductName,
                Description = x.Description,
                Price = x.Price,
                Stock = x.Stock,
                ImageUrl = x.ImageUrl,
                CategoryId = x.CategoryId
            }).ToList();
        }

        public async Task<GetByIdProductDto> GetByIdProductAsync(int id)
        {
            var values = await _productRepository.GetByIdAsync(id);
            return new GetByIdProductDto
            {
                ProductId = values.ProductId,
                ProductName = values.ProductName,
                Description = values.Description,
                Price = values.Price,
                Stock = values.Stock,
                ImageUrl = values.ImageUrl,
                CategoryId = values.CategoryId
            };
        }

        public async Task UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            var values = await  _productRepository.GetByIdAsync(updateProductDto.ProductId);
            values.ProductName = updateProductDto.ProductName;
            values.Description = updateProductDto.Description;
            values.Price = updateProductDto.Price;
            values.Stock = updateProductDto.Stock;
            values.ImageUrl = updateProductDto.ImageUrl;
            values.CategoryId = updateProductDto.CategoryId;
            await _productRepository.UpdateAsync(values);
        }
    }
}
