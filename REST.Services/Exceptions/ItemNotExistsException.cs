namespace REST.Services.Exceptions;

public class ItemNotExistsException : Exception
{
    public ItemNotExistsException(int id) : base($"Item with id = {id} does not exist in the database")
    {
        
    }
}