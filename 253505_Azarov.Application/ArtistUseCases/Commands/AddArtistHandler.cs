namespace _253505_Azarov.Application.ArtistUseCases.Commands;
internal class AddArtistHandler(IUnitOfWork unitOfWork) :
 IRequestHandler<AddArtistCommand>
{
    public async Task Handle(AddArtistCommand request, 
        CancellationToken cancellationToken)
    {
        await unitOfWork.ArtistRepository.AddAsync(request.Artist, cancellationToken);
        await unitOfWork.SaveAllAsync();
    }
}
