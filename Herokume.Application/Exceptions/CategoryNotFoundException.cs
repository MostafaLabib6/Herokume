namespace Herokume.Application.Exceptions;

public class CategoryNotFoundException : BaseException
{
    public CategoryNotFoundException(string type, Guid Id) : base($"{type} with Key {Id} Not Found")
    {

    }
}
