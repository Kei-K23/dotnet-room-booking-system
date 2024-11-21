using Microsoft.EntityFrameworkCore;
using RoomBookAPI.Models;

namespace RoomBookAPI.ApplicationDbContext
{
    public class AppDbContext(DbContextOptions<AppDbContext> contextOptions) : DbContext(contextOptions)
    {
        public DbSet<User> Users { get; set; }
    }

}
