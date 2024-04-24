using TechNova.Shared.Classes.DTOs.Response;
using TechNova.Shared.Classes.Entities;

namespace TechNova.Shared.Interfaces;

public interface IOrderService
{
    Task CreateOrderAsync(OrderFormModel order);
    Task<Cart> GetUserCartAsync(string userId);
    Task RenewUserCartAsync(string userId);
    Task AddToUserCartAsync(ProductResponseDTO product, string userId);
}
