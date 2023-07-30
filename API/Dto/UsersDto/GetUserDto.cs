namespace API.Dto.UsersDto
{
    public class GetUserDto
    {

        public string Name { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string PasswordHash { get; set; } = string.Empty;

    }
}
