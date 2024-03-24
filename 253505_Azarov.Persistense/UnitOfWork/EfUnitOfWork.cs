using _253505_Azarov.Persistense.Data;
using _253505_Azarov.Persistense.Repository;

namespace _253505_Azarov.Persistense.UnitOfWork;
public class EfUnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;
    private readonly Lazy<IRepository<Artist>> _artistRepository;
    private readonly Lazy<IRepository<Song>> _songRepository;
 
    public EfUnitOfWork(AppDbContext context)
    {
        _context = context;
        _artistRepository = new Lazy<IRepository<Artist>>(() =>
            new EfRepository<Artist>(context));
        _songRepository = new Lazy<IRepository<Song>>(() => 
            new EfRepository<Song>(context));
    }
    public IRepository<Artist> ArtistRepository => 
        _artistRepository.Value;
    public IRepository<Song> SongRepository => 
        _songRepository.Value; 
    public async Task CreateDatabaseAsync() => 
        await _context.Database.EnsureCreatedAsync(); 
    public async Task RemoveDatabaseAsync() =>
        await _context.Database.EnsureDeletedAsync();
    public async Task SaveAllAsync() => 
        await _context.SaveChangesAsync();
}
