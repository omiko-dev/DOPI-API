using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class User
    {

        public required int Id { get; set; }

        public required string Email { get; set; }

        public required string Name { get; set; }

        public required string Password { get; set; }

        public List<Product>? Cart { get; set; }

        public List<Product>? PurchaseProduct { get; set; }
        

    }
}
