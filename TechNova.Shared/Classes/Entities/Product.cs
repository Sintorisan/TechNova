namespace TechNova.Shared.Classes.Entities;

public class Product
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public double Price { get; set; }
    public string ImgUri { get; set; } = string.Empty;
    public string ShortDescription { get; set; } = string.Empty;
    public string LongDescription { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public bool OnSale { get; set; }
    public double Discount { get; set; } // Discount percent
    public double DiscountPrice { get; set; }
    public ICollection<Category> Categories { get; set; } = new List<Category>();
    public ICollection<Order> Orders { get; set; } = new List<Order>();
}
