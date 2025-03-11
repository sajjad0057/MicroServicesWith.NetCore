namespace BuildingBlocks.Exceptions;

public class BadRequestException : Exception
{
    public readonly string? Details;
    public BadRequestException() : base() { }
    public BadRequestException(string message) : base(message) { }

    public BadRequestException(string message, string details) : base(message)
    {
        Details = details;
    }
}
