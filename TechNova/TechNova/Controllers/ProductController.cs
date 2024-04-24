using Microsoft.AspNetCore.Mvc;
using TechNova.Shared.Classes.DTOs.Response;
using TechNova.Shared.Interfaces;

namespace TechNova.Controllers;

[Route("api/product")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductQuery _productRepository;
    public ProductController(IProductQuery productRepository)
    {
        _productRepository = productRepository;
    }


    [HttpGet("all")]
    public async Task<ActionResult<List<ProductResponseDTO>>> GetAllProducts()
    {
        try
        {
            var response = await _productRepository.GetAllProductsAsync();

            return Ok(response);
        }
        catch (Exception ex)
        {

            return StatusCode(500, $"An unexpected error occurred: {ex.Message}");
        }

    }

    [HttpGet("{productId}")]
    public async Task<ActionResult<ProductResponseDTO>> GetProductById(int productId)
    {
        try
        {
            var response = await _productRepository.GetSingelProductByIdAsync(productId);

            return Ok(response);
        }
        catch (ArgumentNullException)
        {
            return NotFound("No product found");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"An unexpected error occurred: {ex.Message}");
        }
    }

    [HttpGet("category/{categoryId}")]
    public async Task<ActionResult<List<ProductResponseDTO>>> GetAllProductsInCategory(int categoryId)
    {
        try
        {
            var response = await _productRepository.GetAllProductsInCategoryAsync(categoryId);

            return Ok(response);
        }
        catch (Exception ex)
        {

            return StatusCode(500, $"An unexpected error occurred: {ex.Message}");
        }
    }

    [HttpGet("discount")]
    public async Task<ActionResult<List<ProductResponseDTO>>> GetAllProductsDiscount()
    {
        try
        {
            var response = await _productRepository.GetAllProductsDiscountAsync();

            return Ok(response);
        }
        catch (Exception ex)
        {

            return StatusCode(500, $"An unexpected error occurred: {ex.Message}");
        }
    }

    [HttpGet("discount/{categoryId}")]
    public async Task<ActionResult<List<ProductResponseDTO>>> GetAllProductsInCategoryDiscount(int categoryId)
    {
        try
        {
            var response = await _productRepository.GetAllProductsInCategoryDiscountAsync(categoryId);

            return Ok(response);
        }
        catch (Exception ex)
        {

            return StatusCode(500, $"An unexpected error occurred: {ex.Message}");
        }
    }
}
