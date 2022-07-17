namespace REST.DataAccess.Entities;

public class Item : BaseEntity
{
    public int CategoryId { get; set; }
    public string Title { get; set; }
    public string Text { get; set; }

    public virtual Category Category { get; set; }
}