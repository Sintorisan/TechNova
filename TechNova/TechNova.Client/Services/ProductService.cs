using System.Net.Http.Json;
using TechNova.Shared.Classes.DTOs.Response;
using TechNova.Shared.Classes.Entities;
using TechNova.Shared.Interfaces;

namespace TechNova.Client.Services;

public class ProductService : IProductQuery
{
    private readonly HttpClient _httpClient;

    public ProductService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<ProductResponseDTO>> GetAllProductsAsync()
    {
        var response = await _httpClient.GetFromJsonAsync<List<ProductResponseDTO>>("api/product/all");

        return response;
    }

    public async Task<List<ProductResponseDTO>> GetAllProductsDiscountAsync()
    {
        var response = await _httpClient.GetFromJsonAsync<List<ProductResponseDTO>>("api/product/discount");

        return response;
    }

    public async Task<List<ProductResponseDTO>> GetAllProductsInCategoryAsync(int categoryId)
    {
        var response = await _httpClient.GetFromJsonAsync<List<ProductResponseDTO>>("api/product/category/{categoryId}");

        return response;
    }

    public async Task<List<ProductResponseDTO>> GetAllProductsInCategoryDiscountAsync(int categoryId)
    {
        var response = await _httpClient.GetFromJsonAsync<List<ProductResponseDTO>>("api/product/discount/{categoryId}");

        return response;
    }

    public async Task<ProductResponseDTO> GetSingelProductByIdAsync(int productId)
    {
        var response = await _httpClient.GetFromJsonAsync<ProductResponseDTO>("api/product/{productId}");

        return response;
    }

    public Task<Product> GetSingelProductEntityByIdAsync(int productId)
    {
        throw new NotImplementedException();
    }

    public Task UpdateProduct(Product product)
    {
        throw new NotImplementedException();
    }
}
