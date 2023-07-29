using Microsoft.AspNetCore.Identity;
using System.Diagnostics.CodeAnalysis;

namespace API.Models
{
    public class User
    {

        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;
        
        public string Email { get; set; } = string.Empty;

        public string PasswordHash { get; set; } = string.Empty;

        public string role { get; set; } = "user";

        [MaybeNull]
        public string refreshToken { get; set; }

        [MaybeNull]
        public DateTime? tokenCreate { get; set; }

        [MaybeNull]
        public DateTime? tokenExpires { get; set; }

        [MaybeNull]
        public ICollection<UserCart>? UserCart { get; set; }

        public ICollection<PurchaseProduct>? PurchaseProduct { get; set; }

    }
}
