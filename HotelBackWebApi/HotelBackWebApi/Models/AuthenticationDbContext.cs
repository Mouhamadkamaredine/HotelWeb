using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HotelBackWebApi.Models
{
    public class AuthenticationContext:IdentityDbContext
    {
        public AuthenticationContext( DbContextOptions<AuthenticationContext> options):base(options)
        {

        }
        public DbSet<AplicationUser>AplicationUsers { get; set; }
    }
}
