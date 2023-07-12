using API.Services;
using Azure.Core.Pipeline;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _context;

        public ProductController(IProductRepository context)
        {
            _context = context;
        }

        [HttpPost]
        async public Task<ActionResult<Product>> AddProduct(Product product)
        {
            return await _context.AddProduct(product);
        }

        [HttpGet]
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
            return await _context.UpdateProduct(id, product);
        }

        [HttpDelete("{id}")]
        async public Task<ActionResult<Product>> DeleteProduct(int id)
        {
            return await _context.DeleteProduct(id);
        }

    }
}
