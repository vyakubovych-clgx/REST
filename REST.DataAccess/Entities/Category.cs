namespace REST.DataAccess.Entities;

public class Category : BaseEntity
{
    public string Name { get; set; }
    public virtual ICollection<Item> Items { get; set; }
}