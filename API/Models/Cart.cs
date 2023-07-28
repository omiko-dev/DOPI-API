using API.Models.Enums;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace API.Models
{
    public class Cart : Product
    {

        [MaybeNull]
        public ICollection<UserCart> UserCart { get; set; }


    }
}
