using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shoper.Application.Dtos.ProductDtos;
using Shoper.Application.Usecasess.ProductServices;

namespace Shoper.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductServices _productServices;
        public ProductsController(IProductServices productServices)
        {
            _productServices = productServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProduct()
        {
            var product = await _productServices.GetAllProductAsync();
            return Ok(product);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdProduct(int id)
        {
            var product = await _productServices.GetByIdProductAsync(id);
            return Ok(product);
        }

        [HttpPost]//create işlemleri genellikle post ile yapılır.
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            await _productServices.CreateProductAsync(createProductDto);
            return Ok("Ürün Ekleme İşlemi Başarılı!");
        }


        [HttpPut]//update işlemleri genellikle put ile yapılır.
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        {
            await _productServices.UpdateProductAsync(updateProductDto);
            return Ok("Ürün Güncelleme İşlemi Başarılı!");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _productServices.DeleteProductAsync(id);
            return Ok("Ürün Başarıyla Silindi!");
        }

    }
}
