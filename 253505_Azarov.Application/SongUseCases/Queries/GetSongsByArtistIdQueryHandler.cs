namespace _253505_Azarov.Application.SongUseCases.Queries;
internal class GetSongsByArtistIdQueryHandler(IUnitOfWork unitOfWork) :
 IRequestHandler<GetSongsByArtistIdQuery, IEnumerable<Song>>
{
    public async Task<IEnumerable<Song>> Handle(GetSongsByArtistIdQuery request, 
        CancellationToken cancellationToken)
    {
        return await unitOfWork
            .SongRepository
            .ListAsync(s => 
                    s.ArtistId.Equals(request.Id), 
            cancellationToken);
    }

}