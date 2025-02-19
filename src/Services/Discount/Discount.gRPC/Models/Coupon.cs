namespace Discount.gRPC.Models;

public class Coupon
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string ProductName { get; set; } = default!;
    public string Description { get; set; } = default!;
    public int Amount { get; set; }
}
