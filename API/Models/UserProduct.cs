namespace API.Models
{
    public class UserCart
    {

        public int UserId { get; set; }
        public int CartId { get; set; }
        public User User { get; set; }

        public Cart Cart { get; set; }


    }
}
