namespace _253505_Azarov.Application.SongUseCases.Queries;
public sealed record GetSongByIdQuery(int Id): IRequest<Song>
{
    
}