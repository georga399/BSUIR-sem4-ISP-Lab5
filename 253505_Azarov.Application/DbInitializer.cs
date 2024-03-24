using Microsoft.Extensions.DependencyInjection;
using LoremNET;
namespace _253505_Azarov.Application;
public static class DbInitializer
{
    public static async Task Initialize(IServiceProvider services)
    {
        var unitOfWork = services.GetRequiredService<IUnitOfWork>();

        // Создать базу данных заново
        await unitOfWork.RemoveDatabaseAsync();
        await unitOfWork.CreateDatabaseAsync();
        // Добавить artists 
        IReadOnlyList<Artist> artists = new List<Artist>()
            {
            new (){Name="Eminem", Description="white rapper." },
            new (){Name="Blur", Description="rock group." },
            new (){Name="Ice cube", Description="Black rapper." },
            };

        foreach (var artist in artists)
            await unitOfWork.ArtistRepository.AddAsync(artist);
        
        await unitOfWork.SaveAllAsync();
        // добавить songs
        var counter = 1;
        foreach (var artist in artists)
        {
            for (int j = 0; j < 6; j++)
            {
                await unitOfWork.SongRepository.AddAsync(new()
                {
                    Artist = artist,
                    Title = Lorem.Words(1),
                    Description = Lorem.Words(10),
                    Position=counter,
                    Genre="rap"
                });
                counter++;
            }
        }
        // НЕ забудьте записать слушателя на курс
        await unitOfWork.SaveAllAsync();
 }
}