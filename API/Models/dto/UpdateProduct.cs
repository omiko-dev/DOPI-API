using API.Models.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models.dto
{
    public class UpdateProduct
    {

        public string? ProductName { get; set; } = string.Empty;

        public string? Description { get; set; } = string.Empty;

        public string? Brand { get; set; } = string.Empty;

        public int Price { get; set; }

        public string? Ingredients { get; set; } = string.Empty;

        public int CocoaPercentage { get; set; }

        public Flavor Flavor { get; set; }

        public string? Allergens { get; set; } = string.Empty;

        public string? ImageURL { get; set; } = string.Empty;

    }
}
