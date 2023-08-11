using System.Diagnostics.CodeAnalysis;

namespace API.Models
{
    public class Cart : Product
    {

        public int Count { get; set; } = 1;

        public int Userid { get; set; }


    }
}
