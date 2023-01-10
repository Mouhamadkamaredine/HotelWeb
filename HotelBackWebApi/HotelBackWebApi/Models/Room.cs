using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBackWebApi.Models
{
    public class Room
    {
        [Key]
       
        public int RoomTypeId { get; set; }
        
        public int RoomNb { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string RoomName { get; set; }

        [Column(TypeName = "nvarchar(500)")]
        public string Descreption { get; set; }

        public int Cost { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string BedType { get; set; }
        public int Geusts { get; set; }
        public int RoomSize { get; set; }

        public string RoomImage { get; set; }
    }
}
