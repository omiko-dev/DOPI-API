namespace API.Dto.UsersDto
{
    public class RegisterDto
    {

        public required string Email { get; set; }

        public required string Name { get; set; }

        public required string PasswordHash { get; set; }

    }
}
