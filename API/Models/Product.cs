using API.Models.Enums;
using Microsoft.EntityFrameworkCore;
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

        public int Price { get; set; }

        [NotMapped]
        public List<string> Ingredients { get; set; }

        public int CocoaPercentage { get; set; }

        public Flavor Flavor { get; set; }

        [NotMapped]
        public List<string> Allergens { get; set; }

        [NotMapped]
        public List<string> ImageURL { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

    }


}
