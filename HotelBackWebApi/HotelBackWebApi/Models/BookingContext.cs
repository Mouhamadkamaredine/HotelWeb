using Microsoft.EntityFrameworkCore;

namespace HotelBackWebApi.Models
{
    public class BookingContext : DbContext
    {
        public BookingContext(DbContextOptions<BookingContext> options) : base(options)
        {

        }

        public DbSet<Booking> Book { get; set; }
    }
}