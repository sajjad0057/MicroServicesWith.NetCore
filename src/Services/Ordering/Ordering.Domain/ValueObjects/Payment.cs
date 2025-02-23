
namespace Ordering.Domain.ValueObjects;

public record Payment
{
    public string? CardName { get; set; } = default!;
    public string CardNumber { get; init; } = default!;
    public string CardHolderName { get; init; } = string.Empty;
    public DateTime Expiration { get; init; }
    public string CVV { get; init; } = default!;
    public int PaymentMethod { get; init; } = default!;
}
