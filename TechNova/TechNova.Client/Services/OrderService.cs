using System.Net.Http.Json;
using TechNova.Shared.Classes.DTOs.Response;
using TechNova.Shared.Classes.Entities;
using TechNova.Shared.Interfaces;

namespace TechNova.Client.Services;

public class OrderService : IOrderService
{
    private readonly HttpClient _httpClient;

    public OrderService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task AddToUserCartAsync(ProductResponseDTO product, string userId)
    {
        await _httpClient.PostAsJsonAsync($"api/order/{userId}", product);
    }

    public async Task CreateOrderAsync(OrderFormModel order)
    {
        await _httpClient.PostAsJsonAsync("api/order", order);
    }

    public async Task<Cart> GetUserCartAsync(string userId)
    {
        var response = await _httpClient.GetFromJsonAsync<Cart>($"api/order/{userId}");

        return response;
    }

    public async Task RenewUserCartAsync(string userId)
    {
        await _httpClient.PostAsync($"api/order/renew/{userId}", null);
    }
}
