namespace Herokume.Application.Exceptions;

public class EpsiodeNotFoundException : BaseException
{
    public EpsiodeNotFoundException(string type, Guid Id) : base($"{type} with Key {Id} Not Found")
    {

    }
}
