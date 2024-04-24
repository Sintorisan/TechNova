using Microsoft.EntityFrameworkCore;
using TechNova.Data;
using TechNova.Shared.Classes.DTOs.Response;
using TechNova.Shared.Classes.Entities;
using TechNova.Shared.Interfaces;
using TechNova.Shared.Mappers;

namespace TechNova.Services
{
    public class ProductService : IProductQuery
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IProductMapper _mapProduct;
        public ProductService(ApplicationDbContext storeDbContext, IProductMapper productMapper)
        {
            _dbContext = storeDbContext;
            _mapProduct = productMapper;
        }

        public async Task<List<ProductResponseDTO>> GetAllProductsAsync()
        {

            var response = await _dbContext.Products
                .Select(p => _mapProduct.ToResponse(p))
                .ToListAsync();

            return response;
        }

        public async Task<ProductResponseDTO> GetSingelProductByIdAsync(int productId)
        {


            var response = await _dbContext.Products.FirstOrDefaultAsync(p => p.Id == productId);

            if (response is null) throw new ArgumentNullException(nameof(response), "Product not found");

            return _mapProduct.ToResponse(response);
        }

        public async Task<Product> GetSingelProductEntityByIdAsync(int productId)
        {


            var response = await _dbContext.Products.FirstOrDefaultAsync(p => p.Id == productId);

            if (response is null) throw new ArgumentNullException(nameof(response), "Product not found");

            return response;
        }

        public async Task<List<ProductResponseDTO>> GetAllProductsDiscountAsync()
        {

            var response = await _dbContext.Products
                .Where(p => p.OnSale == true)
                .Select(p => _mapProduct.ToResponse(p))
                .ToListAsync();

            return response;
        }

        public async Task<List<ProductResponseDTO>> GetAllProductsInCategoryAsync(int categoryId)
        {

            var response = await _dbContext.Products
                .Include(p => p.Categories)
                .Where(p => p.Categories
                .Any(c => c.Id == categoryId))
                .Select(p => _mapProduct.ToResponse(p))
                .ToListAsync();

            return response;
        }

        public async Task<List<ProductResponseDTO>> GetAllProductsInCategoryDiscountAsync(int categoryId)
        {

            var response = await _dbContext.Products
                .Include(p => p.Categories)
                .Where(p => p.OnSale == true &&
                    p.Categories.Any(c => c.Id == categoryId))
                .Select(p => _mapProduct.ToResponse(p))
                .ToListAsync();

            return response;
        }

        public async Task UpdateProduct(Product product)
        {
            _dbContext.Products.Update(product);
        }

    }
}
