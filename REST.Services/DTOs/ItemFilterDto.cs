using System.ComponentModel.DataAnnotations;

namespace REST.Services.DTOs;

public record ItemFilterDto(
    [Range(1, int.MaxValue)]
    int PageNumber,

    [Range(1, int.MaxValue)]
    int PageSize,

    int? CategoryId = null);