using _253505_Azarov.Application.SongUseCases.Commands;

namespace _253505_Azarov.Application.SongUseCases;
internal class DeleteSongHandler(IUnitOfWork unitOfWork) :
 IRequestHandler<DeleteSongCommand>
{
    public async Task Handle(DeleteSongCommand request, 
        CancellationToken cancellationToken)
    {
        await unitOfWork.SongRepository.DeleteAsync(request.Song, cancellationToken);
        await unitOfWork.SaveAllAsync();
    }
}