using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class UserProduct : Product
    {
        
        public bool Buy { get; set; } = false;

        public int UserId { get; set; }
        public User User { get; set; } = null!;

    }
}
