using Microsoft.EntityFrameworkCore;

namespace HotelBackWebApi.Models
{
    public class RoomContext : DbContext
    {
        public RoomContext(DbContextOptions<RoomContext> options) : base(options)
        {

        }
      
        public DbSet<Room> Rooms { get; set; }
    }
}