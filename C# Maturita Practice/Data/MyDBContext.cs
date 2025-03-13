using C__Maturita_Practice.Models;
using Microsoft.EntityFrameworkCore;

namespace C__Maturita_Practice.Data
{
    public class MyDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Note> Notes { get; set; }

        public MyDBContext(DbContextOptions<MyDBContext> options) : base(options) { }
    }
}
