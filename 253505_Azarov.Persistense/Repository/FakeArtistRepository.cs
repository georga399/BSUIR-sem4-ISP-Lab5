using System.Linq.Expressions;
namespace _253505_Azarov.Persistense.Repository;
public class FakeArtistRepository : IRepository<Artist>
{
    private readonly List<Artist> _artists;

    public FakeArtistRepository()
    {
        _artists = new List<Artist>()
        {
            new Artist()
            {
                Name = "Eminem",
                Description = "Popular rap singer",
                isVerified = true,
                Songs = new List<Song>()
            },
            new Artist()
            {
                Name = "Ice Cube",
                Description = "Rap singer",
                isVerified = true,
                Songs = new List<Song>()
            }
        };
    }

    public Task AddAsync(Artist entity, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Artist entity, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<Artist> FirstOrDefaultAsync(Expression<Func<Artist, bool>> filter, 
        CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<Artist> GetByIdAsync(int id, 
        CancellationToken cancellationToken = default, 
        params Expression<Func<Artist, object>>[]? includesProperties)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyList<Artist>> ListAllAsync(CancellationToken cancellationToken = default)
    {
        return Task.Run(() => _artists as IReadOnlyList<Artist>);
    }

    public Task<IReadOnlyList<Artist>> ListAsync(Expression<Func<Artist, bool>> filter, 
        CancellationToken cancellationToken = default, 
        params Expression<Func<Artist, object>>[]? includesProperties)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Artist entity, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}