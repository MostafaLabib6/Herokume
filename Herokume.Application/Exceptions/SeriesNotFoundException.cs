namespace Herokume.Application.Exceptions;

public class SeriesNotFoundException : BaseException
{
    public SeriesNotFoundException(string type, Guid Id) : base($"{type} with Key {Id} Not Found")
    {

    }
}
