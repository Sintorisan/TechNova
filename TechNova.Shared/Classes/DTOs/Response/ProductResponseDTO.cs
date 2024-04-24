using TechNova.Shared.Classes.Entities;
using TechNova.Shared.Enums;

namespace TechNova.Shared.Classes.DTOs.Response;

public class ProductResponseDTO
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public double OriginalPrice { get; set; }
    public double Price => Currency.CurrencyId == CurrencyId.Euro ? OriginalPrice : Math.Round(OriginalPrice * Currency.ExchangeRate, 2);
    public Currency Currency { get; set; } = new Currency();
    public string ImgUri { get; set; } = "./img/Products/placeholder.jpg";
    public string ShortDescription { get; set; } = string.Empty;
    public string LongDescription { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public bool OnSale { get; set; }
    public double Discount { get; set; }
    public double DiscountPrice => OnSale ? Math.Round(Price - Discount / 100 * Price) - 0.01 : Price;
    public ICollection<int> CategoriesId { get; set; } = new List<int>();
    public ICollection<Cart> Carts { get; set; } = new List<Cart>();
}
