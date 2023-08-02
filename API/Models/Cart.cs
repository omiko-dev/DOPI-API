using System.Diagnostics.CodeAnalysis;

namespace API.Models
{
    public class Cart : Product
    {

        [MaybeNull]
        public ICollection<UserCart> UserCart { get; set; }


    }
}
