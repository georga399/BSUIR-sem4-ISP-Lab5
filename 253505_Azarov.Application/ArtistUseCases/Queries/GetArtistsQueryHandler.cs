namespace _253505_Azarov.Application.ArtistUseCases.Queries;
internal class GetTraineesByGroupRequestHandler(IUnitOfWork unitOfWork) :
 IRequestHandler<GetArtistsQuery, IEnumerable<Artist>>
{
    public async Task<IEnumerable<Artist>> Handle(GetArtistsQuery request, 
        CancellationToken cancellationToken)
    {
        return await unitOfWork.ArtistRepository.ListAllAsync(cancellationToken);
    
    }

}
