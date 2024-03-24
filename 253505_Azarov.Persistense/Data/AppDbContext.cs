using Microsoft.EntityFrameworkCore;
namespace _253505_Azarov.Persistense.Data;
public class AppDbContext : DbContext
{
    DbSet<Artist> Atrists { get; }
    DbSet<Song> Songs { get; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
}
