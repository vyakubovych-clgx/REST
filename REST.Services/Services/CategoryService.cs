using AutoMapper;
using REST.DataAccess.Entities;
using REST.DataAccess.Interfaces;
using REST.Services.DTOs;
using REST.Services.Exceptions;
using REST.Services.Interfaces;

namespace REST.Services.Services;

public class CategoryService : ICategoryService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    public IEnumerable<CategoryDto> GetAll()
    {
        var entities = _unitOfWork.CategoryRepository.GetAllWithItems();
        return _mapper.Map<IEnumerable<CategoryDto>>(entities);
    }

    public async Task<CategoryDto> GetByIdAsync(int id)
    {
        var entity = await _unitOfWork.CategoryRepository.GetByIdWithItemsAsync(id).ConfigureAwait(false);
        return entity is null ? null : _mapper.Map<CategoryDto>(entity);
    }

    public async Task<CategoryDto> AddAsync(AddUpdateCategoryDto model)
    {
        var entity = _mapper.Map<Category>(model);
        await _unitOfWork.CategoryRepository.AddAsync(entity).ConfigureAwait(false);
        await _unitOfWork.SaveAsync().ConfigureAwait(false);
        return _mapper.Map<CategoryDto>(entity);
    }

    public async Task UpdateAsync(int id, AddUpdateCategoryDto model)
    {
        var categoryToUpdate = await TryGetCategoryAsync(id).ConfigureAwait(false);
        _mapper.Map(model, categoryToUpdate);
        _unitOfWork.CategoryRepository.Update(categoryToUpdate);
        await _unitOfWork.SaveAsync().ConfigureAwait(false);
    }

    public async Task DeleteByIdAsync(int id)
    {
        var category = await TryGetCategoryAsync(id).ConfigureAwait(false);

        foreach (var item in category.Items)
            _unitOfWork.ItemRepository.Delete(item);

        _unitOfWork.CategoryRepository.Delete(category);
        await _unitOfWork.SaveAsync().ConfigureAwait(false);
    }

    private async Task<Category> TryGetCategoryAsync(int id)
    {
        var category = await _unitOfWork.CategoryRepository.GetByIdAsync(id).ConfigureAwait(false);
        if (category is null)
            throw new CategoryNotExistsException(id);

        return category;
    }
}