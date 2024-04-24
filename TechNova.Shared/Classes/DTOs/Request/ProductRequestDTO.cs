namespace TechNova.Shared.Classes.DTOs.Request;

public class ProductRequestDTO
{
    public string Title { get; set; } = string.Empty;
    public double Price { get; set; }
    public string ImgUri { get; set; } = string.Empty;
    public string ShortDescription { get; set; } = string.Empty;
    public string LongDescription { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public bool OnSale { get; set; }
    public double Discount { get; set; }
    public ICollection<int> CategoriesId { get; set; } = new List<int>();
    public ICollection<int>? CartsId { get; set; } = new List<int>();
}
