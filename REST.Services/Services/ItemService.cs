using AutoMapper;
using REST.DataAccess.Entities;
using REST.DataAccess.Interfaces;
using REST.Services.DTOs;
using REST.Services.Exceptions;
using REST.Services.Interfaces;

namespace REST.Services.Services;

public class ItemService : IItemService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ItemService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public IEnumerable<ItemDto> GetByFilter(ItemFilterDto filter)
    {
        var entities = _unitOfWork.ItemRepository.GetAll();
        if (filter.CategoryId is not null)
            entities = entities.Where(i => i.CategoryId == filter.CategoryId);
        entities = entities.Skip((filter.PageNumber - 1) * filter.PageSize).Take(filter.PageSize);
        return _mapper.Map<IEnumerable<ItemDto>>(entities);
    }

    public async Task<ItemDto> GetByIdAsync(int id)
    {
        var entity = await _unitOfWork.ItemRepository.GetByIdAsync(id).ConfigureAwait(false);
        return entity is null ? null : _mapper.Map<ItemDto>(entity);
    }

    public async Task<ItemDto> AddAsync(AddUpdateItemDto model)
    {
        await ValidateNewItemDtoAsync(model).ConfigureAwait(false);
        var entity = _mapper.Map<Item>(model);
        await _unitOfWork.ItemRepository.AddAsync(entity).ConfigureAwait(false);
        await _unitOfWork.SaveAsync().ConfigureAwait(false);
        return _mapper.Map<ItemDto>(entity);
    }

    public async Task UpdateAsync(int id, AddUpdateItemDto model)
    {
        await ValidateNewItemDtoAsync(model).ConfigureAwait(false);
        var itemToUpdate = await TryGetItemAsync(id).ConfigureAwait(false);
        _mapper.Map(model, itemToUpdate);
        _unitOfWork.ItemRepository.Update(itemToUpdate);
        await _unitOfWork.SaveAsync().ConfigureAwait(false);
    }

    public async Task DeleteByIdAsync(int id)
    {
        var item = await TryGetItemAsync(id).ConfigureAwait(false);
        _unitOfWork.ItemRepository.Delete(item);
        await _unitOfWork.SaveAsync().ConfigureAwait(false);
    }

    private async Task<Item> TryGetItemAsync(int id)
    {
        var item = await _unitOfWork.ItemRepository.GetByIdAsync(id).ConfigureAwait(false);
        if (item is null)
            throw new ItemNotExistsException(id);

        return item;
    }

    private async Task ValidateNewItemDtoAsync(AddUpdateItemDto model)
    {
        if (await _unitOfWork.CategoryRepository.GetByIdAsync(model.CategoryId).ConfigureAwait(false) is null)
            throw new CategoryNotExistsException(model.CategoryId);
    }
}