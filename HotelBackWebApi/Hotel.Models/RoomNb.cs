using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Models
{
    public class RoomNb
    {
        public int ID { get; set; }
      
       
        public int RoomId { get; set; }
        public int RoomNumber { get; set; }


        public string RoomName { get; set; }
        public string Descreption { get; set; }
        public int Cost { get; set; }
        public string BedType { get; set; }
        public int Geusts { get; set; }
        public int RoomSize { get; set; }
        public string RoomImage { get; set; }
    }
}
