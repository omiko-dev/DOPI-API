using API.Models.dto;

namespace API.Services
{
    public interface IProductRepository
    {


        public Task<IEnumerable<Product>> GetProducts();

        public Task<Product> GetProductById(int id);

        public Task<Product> AddProduct(Product product);

        public Task<Product> UpdateProduct(int id, UpdateProduct product);

        public Task<Product> DeleteProduct(int id);





    }
}
