using _253505_Azarov.Persistense.Data;
using _253505_Azarov.Persistense.Repository;

namespace _253505_Azarov.Persistense.UnitOfWork;
    public class FakeUnitOfWork : IUnitOfWork
    {
        private readonly FakeArtistRepository _artistRepository;
        private readonly FakeSongRepository _songsRepository;

        public FakeUnitOfWork()
        {
            _artistRepository = new();
            _songsRepository = new();
        }
        public IRepository<Artist> ArtistRepository => _artistRepository;

        public IRepository<Song> SongRepository => _songsRepository;

        public Task CreateDatabaseAsync()
        {
            throw new NotImplementedException();
        }

        public Task RemoveDatabaseAsync()
        {
            throw new NotImplementedException();
        }

        public Task SaveAllAsync()
        {
            throw new NotImplementedException();
        }
    }