using Microsoft.AspNetCore.Identity;

namespace API.Models
{
    public class User
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public string role { get; set; }

        public string refreshToken { get; set; }

        public DateTime tokenCreate { get; set; }

        public DateTime tokenExpires { get; set; }

        public ICollection<UserCart> UserCart { get; set; }

    }
}
