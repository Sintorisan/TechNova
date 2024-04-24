namespace TechNova.Shared.Classes.Entities;

public class Order
{
    public int Id { get; set; }
    public OrderFormModel OrderForm { get; set; } = new();
    public ICollection<Product> Products { get; set; } = new List<Product>();

}