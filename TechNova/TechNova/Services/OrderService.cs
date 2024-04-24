using TechNova.Data;
using TechNova.Shared.Classes.DTOs.Response;
using TechNova.Shared.Classes.Entities;
using TechNova.Shared.Interfaces;
using TechNova.Shared.Mappers;

namespace TechNova.Services;

public class OrderService : IOrderService
{
    private readonly ApplicationDbContext _context;
    private readonly IProductMapper _mapProduct;
    private readonly UserService _userService;
    private readonly IProductQuery _productService;


    public OrderService(ApplicationDbContext context, IProductMapper productMapper, UserService userService, IProductQuery productService)
    {
        _context = context;
        _mapProduct = productMapper;
        _userService = userService;
        _productService = productService;
    }

    async Task<Order> AssembleOrder(OrderFormModel orderForm, Cart cart)
    {
        Order newOrder = new Order();

        newOrder.OrderForm = orderForm;

        foreach (var cartProduct in cart.CartProducts)
        {
            var product = await _productService.GetSingelProductEntityByIdAsync(cartProduct.Id);
            newOrder.Products.Add(product);

            product.Quantity -= cartProduct.Quantity;
        }
        return newOrder;
    }


    public async Task CreateOrderAsync(OrderFormModel order)
    {
        var cart = await GetUserCartAsync(order.UserID);


        var newOrder = await AssembleOrder(order, cart);

        _context.Orders.Add(newOrder);
        await RenewUserCartAsync(order.UserID);

        await _context.SaveChangesAsync();
    }

    public async Task<Cart> GetUserCartAsync(string userId)
    {
        var user = await _userService.GetUserById(userId);

        return user.CurrentCart;
    }

    public async Task AddToUserCartAsync(ProductResponseDTO product, string userId)
    {
        var user = await _userService.GetUserById(userId);
        var cartProduct = _mapProduct.ToCartProduct(product, 1);

        user.CurrentCart.CartProducts.Add(cartProduct);
    }

    public async Task RenewUserCartAsync(string userId)
    {
        var user = await _userService.GetUserById(userId);

        user.CurrentCart.CartProducts.Clear();

        _context.Update(user);
        await _context.SaveChangesAsync();
    }
}
