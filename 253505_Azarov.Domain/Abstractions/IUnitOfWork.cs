using _253505_Azarov.Domain.Entities;

namespace _253505_Azarov.Domain.Abstractions;
public interface IUnitOfWork
{

    IRepository<Artist> ArtistRepository { get; }
    IRepository<Song> SongRepository { get; }
    public Task RemoveDatabaseAsync();
    public Task CreateDatabaseAsync();
    public Task SaveAllAsync();
}