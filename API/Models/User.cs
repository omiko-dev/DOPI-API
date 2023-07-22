using API.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class User
    {

        public int Id { get; set; }

        public string Email { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public string PasswordHash { get; set; } = string.Empty;

        public string role { get; set; } = "user"; // Default Value: User

        public string refreshToken { get; set; } = string.Empty;

        public DateTime tokenCreate { get; set; }

        public DateTime TokenExpires { get; set; }

        public List<Product>? Cart { get; set; }

        public List<Product>? PurchaseProduct { get; set; }
        

    }
}
