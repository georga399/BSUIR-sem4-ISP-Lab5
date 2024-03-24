namespace _253505_Azarov.Application.ArtistUseCases.Commands;
internal class UpdateArtistHandler(IUnitOfWork unitOfWork) :
 IRequestHandler<UpdateArtistCommand>
{
    public async Task Handle(UpdateArtistCommand request, 
        CancellationToken cancellationToken)
    {
        await unitOfWork.ArtistRepository.UpdateAsync(request.Artist, cancellationToken);
        await unitOfWork.SaveAllAsync();
    }
}