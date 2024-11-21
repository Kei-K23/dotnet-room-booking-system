using Microsoft.EntityFrameworkCore;
using RoomBookAPI.Models;

namespace RoomBookAPI.AppDbContext
{
    public class AppDbContext(DbContextOptions<AppDbContext> contextOptions) : DbContext(contextOptions)
    {
        public DbSet<User> Users { get; set; }
    }
}