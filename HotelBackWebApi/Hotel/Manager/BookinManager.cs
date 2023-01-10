using Hotel.Models;
using Hotel.reposetory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Manager
{
    public class BookinManager
    {
        private readonly IBooking _booking;
        public BookinManager(IBooking booking)
        {
            _booking= booking;
           
        }

        public async Task<int> CreateBook(string firstName, string lastName, string email, string phone, string country, string city, string address, string ZipCode, int roomCount, int adult, int child, string checkin,string checkout, string timeArrive,  int roomNb)
        {
            if (adult == default)
            {
                throw new ArgumentException("Number must greater than zero", nameof(adult));
            }
            if (roomCount == default)
            {
                throw new ArgumentException("Number must greater than zero", nameof(roomCount));
            }



            var id = await this._booking.Insert( firstName,  lastName,  email, phone,  country,  city, address,  ZipCode, roomCount,  adult,  child,  checkin,  checkout,  timeArrive,roomNb);




            return id;
        }

        public async Task UpdateBooking(int id, string firstName, string lastName, string email, string phone, string country, string city, string address, string ZipCode, int roomCount, int adult, int child, string checkin, string checkout, string timeArrive,  int roomNb)
        {

            if (adult == default)
            {
                throw new ArgumentException("Number must greater than zero", nameof(adult));
            }
            if (roomCount == default)
            {
                throw new ArgumentException("Number must greater than zero", nameof(roomCount));
            }

            await this._booking.Update(id, firstName, lastName, email, phone, country, city, address, ZipCode, roomCount, adult, child, checkin, checkout, timeArrive,  roomNb);
        }

        public async Task<Booking> RetrieveBookingId(int id)
        {
            var result = await this._booking.SelectById(id);
            if (id <= 0)
            {
                throw new ArgumentException("your Room id must be greater than 0", nameof(id));
            }




            return result;
        }

        public async Task<Booking> CheckAva(string checkin, string checkout)
        {
            var result = await this._booking.ChecKAvailable(checkin,checkout);
           




            return result;
        }

        public IAsyncEnumerable<Booking> GetBooking()

        {
            var result = this._booking.Select();

            return result;
        }
        public async Task DeleteBooking(int id)
        {
            var result = this._booking.SelectById(id);
            if (result == null)
            {
                throw new ArgumentNullException(nameof(id), "User for this Id doesnt Exist ");
            }

            await this._booking.Delete(id);
        }
    }
}
