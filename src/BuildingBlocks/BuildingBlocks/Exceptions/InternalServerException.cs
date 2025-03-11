namespace BuildingBlocks.Exceptions;

public class InternalServerException : Exception
{
    public readonly string? Details;

    public InternalServerException() : base() { }

    public InternalServerException(string message) : base(message)
    {      
    }

    public InternalServerException(string message, string details) : base(message)
    {    
        Details = details;
    }
}
