using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBackWebApi.Models
{
    public class Booking
    {
        [Key]

        public int BookingId { get; set; }

       
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

        public int RoomCount { get; set; }
        public int Adult { get; set; }
        public int Child { get; set; }

        [Column(TypeName = "nvarchar(10)")]
        public string Checkin { get; set; }
        [Column(TypeName = "nvarchar(10)")]
        public string Checkout { get; set; }
        public int RoomNb { get; set; }
      
    }
}
