namespace _253505_Azarov.Application.ArtistUseCases.Commands;
public interface IAddOrUpdateArtistRequest:IRequest
{
    Artist Artist{get;set;}
}