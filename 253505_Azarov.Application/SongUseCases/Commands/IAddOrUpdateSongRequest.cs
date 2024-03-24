namespace _253505_Azarov.Application.SongUseCases;
public interface IAddOrUpdateSongRequest:IRequest
{
    Song Song{get;set;}
}