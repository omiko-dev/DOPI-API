

namespace API.Models
{
    public class PurchaseProduct : Product
    {
        public DateTime AddedTime { get; set; } = DateTime.Now;

        public int Count { get; set; } = 1;

        public int UserId { get; set; }


    }
}
