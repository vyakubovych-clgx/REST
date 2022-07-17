using REST.Services.DTOs;

namespace REST.Services.Interfaces;

public interface IItemService
{
    IEnumerable<ItemDto> GetByFilter(ItemFilterDto filter);
    Task<ItemDto> GetByIdAsync(int id);
    Task<ItemDto> AddAsync(AddUpdateItemDto model);
    Task UpdateAsync(int id, AddUpdateItemDto model);
    Task DeleteByIdAsync(int id);
}