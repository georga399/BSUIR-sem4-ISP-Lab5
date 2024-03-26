namespace _253505_Azarov.Application.SongUseCases.Queries;
internal class GetSongByIdQueryHandler(IUnitOfWork unitOfWork) :
 IRequestHandler<GetSongByIdQuery, Song>
{
    public async Task<Song> Handle(GetSongByIdQuery request, 
        CancellationToken cancellationToken)
    {
        return await unitOfWork
            .SongRepository
            .FirstOrDefaultAsync(s => s.Id == request.Id, cancellationToken);
    }

}