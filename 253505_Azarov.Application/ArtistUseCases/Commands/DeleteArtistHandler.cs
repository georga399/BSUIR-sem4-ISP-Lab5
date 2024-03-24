using _253505_Azarov.Application.ArtistUseCases.Commands;

namespace _253505_Azarov.Application.SongUseCases;
internal class DeleteArtistHandler(IUnitOfWork unitOfWork) :
 IRequestHandler<DeleteArtistCommand>
{
    public async Task Handle(DeleteArtistCommand request, 
        CancellationToken cancellationToken)
    {
        await unitOfWork.ArtistRepository.DeleteAsync(request.Artist, cancellationToken);
        await unitOfWork.SaveAllAsync();
    }
}