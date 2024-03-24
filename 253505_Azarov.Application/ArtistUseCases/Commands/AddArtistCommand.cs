namespace _253505_Azarov.Application.ArtistUseCases.Commands;
public sealed class AddArtistCommand: IAddOrUpdateArtistRequest
{
    public Artist Artist{get;set;}
}