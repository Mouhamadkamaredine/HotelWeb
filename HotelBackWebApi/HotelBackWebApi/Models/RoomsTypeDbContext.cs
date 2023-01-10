using Microsoft.EntityFrameworkCore;


namespace HotelBackWebApi.Models
{
    public class RoomsTypeDbContext: DbContext
    {
        public RoomsTypeDbContext(DbContextOptions<RoomsTypeDbContext> options) : base(options)
        {

        }

        public DbSet<RoomsType> CreateRooms { get; set; }
    }
}

