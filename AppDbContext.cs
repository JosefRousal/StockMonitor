using Microsoft.EntityFrameworkCore;

namespace StockMonitor;

public sealed class AppDbContext : DbContext
{

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Book> Books { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Book>().HasData(new List<Book>()
        {
            new Book
            {
                Id = 1,
                ISBN = "ABC123",
                Title = "123ABC"
            }
        });
    }
}