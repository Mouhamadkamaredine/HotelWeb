using Hotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.reposetory
{
   public interface IBooking
    {

        Task<int> Insert( string firstName, string lastName, string email, string phone,string country,string city,string address,string ZipCode,int roomCount, int adult,int child, string checkin, string checkout, string timeArrive, int roomNb);

        Task Update(int id, string firstName, string lastName, string email, string phone, string country, string city, string address, string ZipCode, int roomCount, int adult, int child, string checkin, string checkout, string timeArrive, int roomNb);
        Task Delete(int id);
        IAsyncEnumerable<Booking> Select();
        Task<Booking> SelectById(int id);
        Task<Booking> ChecKAvailable(string checkin, string checkout);

    }
}
