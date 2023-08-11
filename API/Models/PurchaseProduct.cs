

namespace API.Models
{
    public class PurchaseProduct : Product
    {

        public int Count { get; set; } = 1;

        public int UserId { get; set; }


    }
}
