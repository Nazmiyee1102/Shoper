using Shoper.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shoper.Application;
using Shoper.Application.Dtos.CategoryDtos;

namespace Shoper.Application.Usercases.CategoryServices
{
    public interface ICategoryServices 
    {
        Task<List<ResultCategoryDto>> GetAllCategoryAsync();

        Task<GetByIdCategoryDto> GetByIdCategoryAsync(int id);

        Task CreateCategoryAsync(CreateCategoryDto createCategoryDto);

        Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto);

        Task DeleteCategoryAsync(int id);
    }
}
