using DataLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace DataLibrary.DataAccess
{
    public class MyDbContext : DbContext
    {
        public static string connectionString;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }

        public DbSet<HotelModel> Hotels { get; set; }
        public DbSet<RoomModel> Rooms { get; set; }
        public DbSet<RoomGalleryModel> RoomGallery { get; set; }
        public DbSet<BookedRoomsModel> BookedRooms { get; set; }
    }
}
