namespace _253505_Azarov.Application.ArtistUseCases.Commands;
public sealed class UpdateArtistCommand: IAddOrUpdateArtistRequest
{
    public Artist Artist{get;set;}
}