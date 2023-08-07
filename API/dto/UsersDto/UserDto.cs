namespace API.dto.UsersDto
{
    public class UserDto
    {

        public required string Email { get; set; }

        public required string Name { get; set; }

        public required string PasswordHash { get; set; }

        public ICollection<Cart>? Cart { get; set; }

        public ICollection<PurchaseProduct>? PurchaseProduct { get; set; }
    }
}
