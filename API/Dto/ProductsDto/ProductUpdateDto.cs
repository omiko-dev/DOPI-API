using API.Models.Enums;

namespace API.Dto.ProductsDto
{
    public class ProductUpdateDto
    {

        public string ProductName { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string Brand { get; set; } = string.Empty;

        public float Price { get; set; }

        public List<string>? Ingredients { get; set; }

        public int CocoaPercentage { get; set; }

        public Flavor Flavor { get; set; }

        public List<string>? Allergens { get; set; }

        public List<string>? ImageURL { get; set; }

    }
}
