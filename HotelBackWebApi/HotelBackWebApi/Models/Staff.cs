using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBackWebApi.Models
{
    public class Staff
    {
        [Key]

        public int Id { get; set; }


        [Column(TypeName = "nvarchar(50)")]
        public string FirstName { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string LastName { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Email { get; set; }

        [Column(TypeName = "nvarchar(25)")]
        public string Phone { get; set; }


        [Column(TypeName = "nvarchar(50)")]
        public string Country { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string City { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Address { get; set; }

        [Column(TypeName = "nvarchar(10)")]
        public string ZipCode { get; set; }

       

        [Column(TypeName = "nvarchar(10)")]
        public string DateOfBirth { get; set; }
        [Column(TypeName = "nvarchar(10)")]
        public string Gender { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string Education { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Role { get; set; }
    }
}
