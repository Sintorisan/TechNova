using Microsoft.AspNetCore.Mvc;
using TechNova.Services;
using TechNova.Shared.Classes.DTOs.Response;
using TechNova.Shared.Classes.Entities;
using TechNova.Shared.Interfaces;

namespace TechNova.Controllers;

[Route("api/order")]
[ApiController]
public class OrderController : ControllerBase
{
    private readonly IOrderService _orderService;
    private readonly UserService _userService;

    public OrderController(OrderService orderService, UserService userService)
    {
        _orderService = orderService;
        _userService = userService;
    }


    [HttpPost]
    public async Task<ActionResult> CreateOrder(OrderFormModel order)
    {
        await _orderService.CreateOrderAsync(order);
        return Ok();
    }

    [HttpPost("{userId}")]
    public async Task<ActionResult> AddToUserCart(ProductResponseDTO product, string userId)
    {
        await _orderService.AddToUserCartAsync(product, userId);
        return Ok();
    }

    [HttpGet("{userId}")]
    public async Task<ActionResult<Cart>> GetUserCart(string userId)
    {
        var userCart = await _orderService.GetUserCartAsync(userId);
        return Ok(userCart);
    }

    [HttpPost("renew/{userId}")]
    public async Task<ActionResult> RenewUserCart(string userId)
    {
        await _orderService.RenewUserCartAsync(userId);
        return Ok();
    }
}
