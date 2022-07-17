using REST.Services.DTOs;

namespace REST.Services.Interfaces;

public interface ICategoryService
{
    IEnumerable<CategoryDto> GetAll();
    Task<CategoryDto> GetByIdAsync(int id);
    Task<CategoryDto> AddAsync(AddUpdateCategoryDto model);
    Task UpdateAsync(int id, AddUpdateCategoryDto model);
    Task DeleteByIdAsync(int id);
}