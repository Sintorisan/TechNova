using TechNova.Shared.Classes.DTOs.Request;
using TechNova.Shared.Classes.DTOs.Response;
using TechNova.Shared.Classes.Entities;

namespace TechNova.Shared.Mappers;

public interface IProductMapper
{
    public ProductResponseDTO ToResponse(Product product);
    public Product ToProduct(ProductRequestDTO request, IEnumerable<Category> categories);
    public Product ToNewProduct(ProductRequestDTO request, IEnumerable<Category> categories);
    public CartProduct ToCartProduct(ProductResponseDTO product, int quantity);
}
public class ProductMapper : IProductMapper
{
    public Product ToProduct(ProductRequestDTO request, IEnumerable<Category> categories)
    {
        return new Product
        {
            Title = request.Title,
            Price = request.Price,
            ImgUri = request.ImgUri,
            ShortDescription = request.ShortDescription,
            LongDescription = request.LongDescription,
            Quantity = request.Quantity,
            OnSale = request.OnSale,
            Categories = new List<Category>(categories),
        };
    }

    public Product ToNewProduct(ProductRequestDTO request, IEnumerable<Category> categories)
    {
        return new Product
        {
            Title = request.Title,
            Price = request.Price,
            ImgUri = request.ImgUri,
            ShortDescription = request.ShortDescription,
            LongDescription = request.LongDescription,
            Quantity = request.Quantity,
            OnSale = request.OnSale,
            Categories = new List<Category>(categories),
        };
    }

    public ProductResponseDTO ToResponse(Product product)
    {
        return new ProductResponseDTO
        {
            Id = product.Id,
            Title = product.Title,
            OriginalPrice = product.Price,
            Currency = new Currency { CurrencyPair = "SEK", ExchangeRate = 1 },
            ImgUri = product.ImgUri,
            ShortDescription = product.ShortDescription,
            LongDescription = product.LongDescription,
            Quantity = product.Quantity,
            OnSale = product.OnSale,
            Discount = product.Discount,
            CategoriesId = product.Categories.Select(c => c.Id).ToList(),
        };
    }

    public CartProduct ToCartProduct(ProductResponseDTO product, int quantity)
    {
        return new CartProduct
        {
            Id = product.Id,
            Title = product.Title,
            ImgUri = product.ImgUri,
            OriginalPrice = product.Price,
            DiscountPrice = product.DiscountPrice,
            OnSale = product.OnSale,
            Quantity = quantity
        };
    }

}
