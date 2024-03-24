namespace _253505_Azarov.Application.SongUseCases.Commands;
public sealed class AddSongCommand: IAddOrUpdateSongRequest
{
    public Song Song{get;set;}
}
