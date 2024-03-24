namespace _253505_Azarov.Application.SongUseCases.Commands;
internal class AddSongHandler(IUnitOfWork unitOfWork) :
 IRequestHandler<AddSongCommand>
{
    public async Task Handle(AddSongCommand request, 
        CancellationToken cancellationToken)
    {
        await unitOfWork.SongRepository.AddAsync(request.Song, cancellationToken);
        await unitOfWork.SaveAllAsync();
    }
}
