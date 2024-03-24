namespace _253505_Azarov.Application.SongUseCases.Queries;
public sealed record GetSongsByArtistIdQuery(int Id): IRequest<IEnumerable<Song>>
{
    
}