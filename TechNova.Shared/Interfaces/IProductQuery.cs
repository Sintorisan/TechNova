using TechNova.Shared.Classes.DTOs.Response;
using TechNova.Shared.Classes.Entities;

namespace TechNova.Shared.Interfaces;

public interface IProductQuery
{
    Task<ProductResponseDTO> GetSingelProductByIdAsync(int productId);
    Task<List<ProductResponseDTO>> GetAllProductsAsync();
    Task<List<ProductResponseDTO>> GetAllProductsInCategoryAsync(int categoryId);
    Task<List<ProductResponseDTO>> GetAllProductsDiscountAsync();
    Task<List<ProductResponseDTO>> GetAllProductsInCategoryDiscountAsync(int categoryId);
    Task<Product> GetSingelProductEntityByIdAsync(int productId);
    Task UpdateProduct(Product product);
}
