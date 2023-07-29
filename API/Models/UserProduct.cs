namespace API.Models
{
    public class UserCart
    {

        public int UserId { get; set; }
        public int CartId { get; set; }
        public required User User { get; set; }

        public required Cart Cart { get; set; }


    }
}
