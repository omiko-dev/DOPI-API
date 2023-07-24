using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace API.Models.dto.UsersDto
{
    public class UserProductDto : Product
    {
        [Key]
        public int UserId { get; set; } 

    }
}
