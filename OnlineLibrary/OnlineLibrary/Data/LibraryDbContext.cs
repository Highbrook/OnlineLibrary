using OnlineLibrary.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace OnlineLibrary.Data
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options) { }
        public DbSet<Book> books { get; set; }
        public DbSet<Category> categories { get; set; }
    }
}
