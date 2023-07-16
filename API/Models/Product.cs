using API.Models.Enums;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Product
    {
        [Key]
        public int Product_Id { get; set; }

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

        public DateTime? CreatedAt { get; set; } 

        public DateTime? UpdatedAt { get; set; }

    }


}
