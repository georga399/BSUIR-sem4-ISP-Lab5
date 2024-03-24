namespace _253505_Azarov.Application.SongUseCases.Commands;
internal class UpdateSongHandler(IUnitOfWork unitOfWork) :
 IRequestHandler<UpdateSongCommand>
{
    public async Task Handle(UpdateSongCommand request, 
        CancellationToken cancellationToken)
    {
        await unitOfWork.SongRepository.UpdateAsync(request.Song, cancellationToken);
        await unitOfWork.SaveAllAsync();
    }
}