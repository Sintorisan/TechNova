using Microsoft.EntityFrameworkCore;
using TechNova.Data;
using TechNova.Shared.Mappers;

namespace TechNova.Services;

public class UserService
{
    private readonly ApplicationDbContext _context;
    private readonly IProductMapper _mapProduct;
    public UserService(ApplicationDbContext context, IProductMapper productMapper)
    {
        _context = context;
        _mapProduct = productMapper;
    }

    public async Task<ApplicationUser> GetUserById(string userId)
    {
        var userWithCart = await _context.Users
            .Include(u => u.CurrentCart)
            .ThenInclude(c => c.CartProducts)
            .FirstOrDefaultAsync(u => u.Id == userId);

        return userWithCart;
    }

}
