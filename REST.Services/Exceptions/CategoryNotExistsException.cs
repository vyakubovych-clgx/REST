namespace REST.Services.Exceptions;

public class CategoryNotExistsException : Exception
{
    public CategoryNotExistsException(int id) : base($"Category with id = {id} does not exist in the database")
    {

    }
}