using Microsoft.AspNetCore.Identity;
using System.Diagnostics.CodeAnalysis;

namespace API.Models
{
    public class User
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public string role { get; set; } = "user";

        [MaybeNull]
        public string refreshToken { get; set; }

        [MaybeNull]
        public DateTime? tokenCreate { get; set; }

        [MaybeNull]
        public DateTime? tokenExpires { get; set; }

        [MaybeNull]
        public ICollection<UserCart>? UserCart { get; set; }

    }
}
