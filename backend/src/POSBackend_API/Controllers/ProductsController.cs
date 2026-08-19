using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using POSBackend_API.Services;

namespace POSBackend_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }


        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            try
            {
                var product = await _productService.GetAllProductsAsync();
                return Ok(product);
            }
            catch (System.Exception ex)
            {
                
                return StatusCode(500, new { success = false, message = ex.Message });
            }
        }
    }
}