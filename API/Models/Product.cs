using API.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        public int Price { get; set; }

        public List<string> Ingredients { get; set; } = new List<string>();

        public int CocoaPercentage { get; set; }

        public Flavor Flavor { get; set; }

        public List<string> Allergens { get; set; } = new List<string>();

        public List<string> ImageURL { get; set; } = new List<string>();

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

    }
}
