using API.Models.Enums;

namespace API.dto.ProductsDto
{
    public class ProductGetDto
    {

        public int Id { get; set; }

        public string ProductName { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string Brand { get; set; } = string.Empty;

        public float Price { get; set; }

        public List<string>? Ingredients { get; set; }

        public int CocoaPercentage { get; set; }

        public Flavor Flavor { get; set; }

        public List<string>? Allergens { get; set; }

        public List<string>? ImageURL { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

    }
}
