namespace TechNova.Shared.Classes.Entities;

public class CartProduct
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string ImgUri { get; set; } = "./img/Products/placeholder.jpg";
    public double OriginalPrice { get; set; }
    public double DiscountPrice { get; set; }
    public bool OnSale { get; set; }
    public int Quantity { get; set; }
    public double Price => OnSale ? DiscountPrice : OriginalPrice;
}
