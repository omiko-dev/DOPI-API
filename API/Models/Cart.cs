using API.Models.Enums;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class Cart
    {

        public int Id { get; set; }

        public string ProductName { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string Brand { get; set; } = string.Empty;

        public float Price { get; set; }

        [NotMapped]
        public List<string>? Ingredients
        {
            get => JsonConvert.DeserializeObject<List<string>>(IngredientsJson!);
            set => IngredientsJson = JsonConvert.SerializeObject(value);
        }

        [Column("Ingredients")]
        public string? IngredientsJson { get; set; }

        public int CocoaPercentage { get; set; }

        public Flavor Flavor { get; set; }

        [NotMapped]
        public List<string>? Allergens
        {
            get => JsonConvert.DeserializeObject<List<string>>(AllergensJson!);
            set => AllergensJson = JsonConvert.SerializeObject(value);
        }

        [Column("Allergens")]
        public string? AllergensJson { get; set; }

        [NotMapped]
        public List<string>? ImageURL
        {
            get => JsonConvert.DeserializeObject<List<string>>(ImageURlJson!);
            set => ImageURlJson = JsonConvert.SerializeObject(value);
        }


        [Column("ImageURL")]
        public string? ImageURlJson { get; set; }

        public bool Buy { get; set; } = false;

        public int UserId { get; set; }

        public User User { get; set; }

    }
}
