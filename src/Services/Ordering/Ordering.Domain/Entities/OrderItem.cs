using Ordering.Domain.Abstractions;

namespace Ordering.Domain.Entities;

public class OrderItem : Entity<Guid>
{
    public Guid OrderId { get; private set; } = default!;
    public Guid ProductId { get; private set; } = default!;
    public decimal Price { get; private set; }
    public int Quantity { get; private set; }

    public OrderItem(Guid orderId, Guid productId, decimal price, int quantity)
    {
        OrderId = orderId;
        ProductId = productId;
        Price = price;
        Quantity = quantity;
    }
}
