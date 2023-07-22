namespace API.Models
{
    public class RefreshToken
    {

        public required string refreshToken { get; set; } 

        public DateTime TokenCreate { get; set; } = DateTime.Now;

        public DateTime TokenExpires { get; set; }


    }
}
