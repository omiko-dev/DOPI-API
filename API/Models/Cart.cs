using API.Models.Enums;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class Cart : Product
    {

        public ICollection<UserCart> UserCart { get; set; }


    }
}
