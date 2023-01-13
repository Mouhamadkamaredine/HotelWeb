using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBackWebApi.Models
{
    public class AplicationUser: IdentityUser
    {
       [Column(TypeName ="nvarchar(150)")]
        public string FullName { get; set; }
       
    }
}
