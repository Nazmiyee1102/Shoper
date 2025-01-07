using Shoper.Application.Dtos.CategoryDtos;
using Shoper.Application.Interfaces;
using Shoper.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoper.Application.Usercases.CategoryServices
{
    public class CategoryServices : ICategoryServices
    {
        private readonly IRepository<Category> _categoryRepository;

        public CategoryServices(IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task CreateCategoryAsync(CreateCategoryDto createCategoryDto)
        {
            await _categoryRepository.CreateAsync(new Category
            {
                CategoryName = createCategoryDto.CategoryName
            });
        }

        public async Task DeleteCategoryAsync(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            await _categoryRepository.DeleteAsync(category);

        }

        public async Task<List<ResultCategoryDto>> GetAllCategoryAsync()
        {
            var categories = await _categoryRepository.GetAllAsync();
            return categories.Select(x => new ResultCategoryDto
            {
                CategoryId = x.CategoryId,
                CategoryName = x.CategoryName
            }).ToList();
        }

        public async Task<GetByIdCategoryDto> GetByIdCategoryAsync(int id)
        {
            var values = await _categoryRepository.GetByIdAsync(id);
            return new GetByIdCategoryDto
            {
                CategoryId = values.CategoryId,
                CategoryName = values.CategoryName
            };
        }

        public async Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
        {
            var category = await _categoryRepository.GetByIdAsync(updateCategoryDto.CategoryId);
            category.CategoryName = updateCategoryDto.CategoryName;
            await _categoryRepository.UpdateAsync(category);
        }
    }
}
