using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shoper.Application.Dtos.CategoryDtos;
using Shoper.Application.Usercases.CategoryServices;

namespace Shoper.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryServices _categoryServices;
        public CategoriesController(ICategoryServices categoryServices)
        {
            _categoryServices = categoryServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await _categoryServices.GetAllCategoryAsync();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdCategory(int id)
        {
            var category = await _categoryServices.GetByIdCategoryAsync(id);
            return Ok(category);
        }

        [HttpPost]//create işlemleri genellikle post ile yapılır.
        public async Task<IActionResult> CreateCategoryAsync(CreateCategoryDto createCategoryDto)
        {
            await _categoryServices.CreateCategoryAsync(createCategoryDto);
            return Ok("Kategori Ekleme İşlemi Başarılı");
        }


        [HttpPut]//update işlemleri genellikle put ile yapılır.
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            await _categoryServices.UpdateCategoryAsync(updateCategoryDto);
            return Ok("Kategori Güncelleme İşlemi Başarılı!");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _categoryServices.DeleteCategoryAsync(id);
            return Ok("Kategori Başarıyla Silindi!");
        }
    }
}
