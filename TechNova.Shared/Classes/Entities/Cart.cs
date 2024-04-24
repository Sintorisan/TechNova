namespace TechNova.Shared.Classes.Entities;

public class Cart
{
    public int Id { get; set; }
    public string UserId { get; set; } = string.Empty;
    public ICollection<CartProduct> CartProducts { get; set; } = new List<CartProduct>();
    public double TotalPrice => CartProducts.Sum(p => p.Price * p.Quantity);

}
