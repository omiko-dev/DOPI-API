using API.dto.ProductsDto;
using API.Dto.ProductsDto;
using API.Services.ProductsService;
using Microsoft.AspNetCore.Authorization;
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
        [ProducesResponseType(typeof(Product), 200)]
        [ProducesResponseType(400)]
        async public Task<ActionResult> AddProduct(ProductAddDto product)
        {
            return Ok(await _context.AddProduct(product));
        }

        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(typeof(IEnumerable<ProductGetDto>), 200)]
        [ProducesResponseType(400)]
        async public Task<ActionResult> GetProducts()
        {
            return Ok(await _context.GetProducts());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProductGetDto), 200)]
        [ProducesResponseType(400)]
        async public Task<ActionResult> GetProductById(int id)
        {
            return Ok(await _context.GetProductById(id));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ProductUpdateDto), 200)]
        [ProducesResponseType(400)]
        async public Task<ActionResult> UpdateProduct(int id, ProductUpdateDto product)
        {
            return Ok(await _context.UpdateProduct(id, product));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Product), 200)]
        [ProducesResponseType(400)]
        async public Task<ActionResult> DeleteProduct(int id)
        {
            return Ok(await _context.DeleteProduct(id));
        }

    }
}
