namespace REST.Services.DTOs;

public record AddUpdateItemDto
{
    public string Title { get; init; }
    public string Text { get; init; }
    public int CategoryId { get; init; }
}