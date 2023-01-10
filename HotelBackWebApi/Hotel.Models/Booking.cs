using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Models
{
   public class Booking
    {
        public int BookingId { get; set; }



        public string FirstName { get; set; }

        public string LastName { get; set; }

     
        public string Email { get; set; }

  
        public string Phone { get; set; }


       
        public string Country { get; set; }

     
        public string City { get; set; }

   
        public string Address { get; set; }

        public string ZipCode { get; set; }

        public int RoomCount { get; set; }
        public int Adult { get; set; }
        public int Child { get; set; }


        public string Checkin { get; set; }
    
        public string Checkout { get; set; }
        public string TimeArrive { get; set; }
     
        public int RoomNb { get; set; }

    }
}
