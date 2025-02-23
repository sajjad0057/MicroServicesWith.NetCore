
namespace Ordering.Domain.ValueObjects;

public record Payment
{
    public string? CardName { get; set; } = default!;
    public string CardNumber { get; init; } = default!;
    public string CardHolderName { get; init; } = string.Empty;
    public DateTime Expiration { get; init; }
    public string CVV { get; init; } = default!;
    public int PaymentMethod { get; init; } = default!;

    protected Payment() { }

    private Payment(string cardName, string cardNumber, string cardHolderName,
        DateTime expiration, string cvv, int paymentMethod)
    {
        CardName = cardName;
        CardNumber = cardNumber;
        CardHolderName = cardHolderName;
        Expiration = expiration;
        CVV = cvv;
        PaymentMethod = paymentMethod;
    }

    public static Payment Of(string cardName, string cardNumber, string cardHolderName,
        DateTime expiration, string cvv, int paymentMethod)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(cardName, nameof(cardName));
        ArgumentException.ThrowIfNullOrWhiteSpace(cardNumber, nameof(cardNumber));       
        ArgumentException.ThrowIfNullOrWhiteSpace(cvv, nameof(cvv));
        ArgumentOutOfRangeException.ThrowIfGreaterThan(cvv.Length, 3, nameof(cvv));

        return new Payment(cardName, cardNumber, cardHolderName, expiration, cvv, paymentMethod);
    }
}
