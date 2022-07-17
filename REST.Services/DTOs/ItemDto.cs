namespace REST.Services.DTOs;

public record ItemDto
{
    public int Id { get; init; }
    public string Title { get; init; }
    public string Text { get; init; }
    public int CategoryId { get; init; }
}