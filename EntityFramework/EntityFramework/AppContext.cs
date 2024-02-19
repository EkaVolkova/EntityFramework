using EntityFramework.Models;
using Microsoft.EntityFrameworkCore;

public class AppContext : DbContext
{
    // Объекты таблицы Users
    public DbSet<User> Users { get; set; }
    public DbSet<Book> Books { get; set; }

    public AppContext()
    {
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=localhost;Database=ef;Trusted_Connection=True;Trust Server Certificate=true;Encrypt=false;");
    }
}

