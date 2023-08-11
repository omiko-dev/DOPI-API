using API.Models.Enums;
using Newtonsoft.Json;

namespace API.dto.UsersDto
{
    public class CartDto
    {
        public int Id { get; set; }

        public string ProductName { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string Brand { get; set; } = string.Empty;

        public float Price { get; set; }

        public List<string>? Ingredients
        {
            get => JsonConvert.DeserializeObject<List<string>>(IngredientsJson!);
            set => IngredientsJson = JsonConvert.SerializeObject(value);
        }

        public string? IngredientsJson { get; set; }

        public int CocoaPercentage { get; set; }

        public Flavor Flavor { get; set; }


        public List<string>? Allergens
        {
            get => JsonConvert.DeserializeObject<List<string>>(AllergensJson!);
            set => AllergensJson = JsonConvert.SerializeObject(value);
        }

        public string? AllergensJson { get; set; }


        public List<string>? ImageURL
        {
            get => JsonConvert.DeserializeObject<List<string>>(ImageURlJson!);
            set => ImageURlJson = JsonConvert.SerializeObject(value);
        }


        public string? ImageURlJson { get; set; }

        public int Count { get; set; } = 1;

        public bool Buy { get; set; } = false;
    }
}
