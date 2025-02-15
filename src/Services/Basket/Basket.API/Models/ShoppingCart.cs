namespace Basket.API.Models;

public class ShoppingCart
{
    public string UserName { get; set; } = default!;
    public List<ShoppingCartItem> Items { get; set; } = new();
    public decimal TotalPrice => Items.Sum(x=> x.Price * x.Quantity);

    /// <summary>
    /// Needing these empty constructor for mapping.
    /// when we declar parameterized constructor then inactivated default constructor
    /// </summary>
    public ShoppingCart()
    {
    }

    public ShoppingCart(string userName)
    {
        UserName = userName;
    }
}
