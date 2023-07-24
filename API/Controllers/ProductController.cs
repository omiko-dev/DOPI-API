using API.Models.dto.ProductsDto;
using API.Services.ProductsService;
using Azure.Core.Pipeline;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "admin")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _context;

        public ProductController(IProductRepository context)
        {
            _context = context;
        }

        [HttpPost]
        async public Task<ActionResult<Product>> AddProduct(ProductAddDto product)
        {
            return await _context.AddProduct(product);
        }

        [HttpGet]
        [AllowAnonymous]
        async public Task<IEnumerable<Product>> GetProducts()
        {
            return await _context.GetProducts();
        }

        [HttpGet("{id}")]
        async public Task<ActionResult<Product>> GetProductById(int id)
        {
            return await _context.GetProductById(id);
        }

        [HttpPut("{id}")]
        async public Task<ActionResult<Product>> UpdateProduct(int id, Product product)
        {
            return Ok(await _context.UpdateProduct(id, product));
        }

        [HttpDelete("{id}")]
        async public Task<ActionResult<Product>> DeleteProduct(int id)
        {
            return await _context.DeleteProduct(id);
        }

    }
}
