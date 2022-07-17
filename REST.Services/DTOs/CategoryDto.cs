namespace REST.Services.DTOs;

public record CategoryDto
{
    public int Id { get; init; }
    public string Name { get; init; }
    public ICollection<int> ItemIds { get; init; }
}