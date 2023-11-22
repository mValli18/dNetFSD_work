using HotelApp.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelApp.Context
{
    public class HotelContext :DbContext
    {
        public HotelContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Hotel>Hotels { get; set; }
        public DbSet<Room>Rooms { get; set; }
        public DbSet<User>Users { get; set; }
    }
}
