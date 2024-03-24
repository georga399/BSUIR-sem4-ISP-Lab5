using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
namespace _253505_Azarov.Persistense.Repository;
public class FakeSongRepository : IRepository<Song>
{
    private readonly List<Song> _songs;

    public FakeSongRepository()
    {
        _songs = new List<Song>();
        for(int i = 1; i<=2; i++)
        {
            for(int j = 0; j < 5; j++)
            {
                _songs.Add(new Song {
                    Title = $"song {j}",
                    Id = (i-1)*5 + j+1,
                    Description = "some description",
                    Genre = "Rap",
                    ArtistId = i,
                    Position=(i-1)*5+j+1
                });
            }
        }
    }

    public Task AddAsync(Song entity, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Song entity, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<Song> FirstOrDefaultAsync(Expression<Func<Song, bool>> filter, 
        CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<Song> GetByIdAsync(int id, 
        CancellationToken cancellationToken = default, 
        params Expression<Func<Song, object>>[]? includesProperties)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyList<Song>> ListAllAsync(CancellationToken cancellationToken = default)
    {
        return Task.Run(() => _songs as IReadOnlyList<Song>);
    }

    public Task<IReadOnlyList<Song>> ListAsync(Expression<Func<Song, bool>> filter, 
        CancellationToken cancellationToken = default, 
        params Expression<Func<Song, object>>[]? includesProperties)
    {
        return Task.Run(() => _songs as IReadOnlyList<Song>);
    }

    public Task UpdateAsync(Song entity, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}