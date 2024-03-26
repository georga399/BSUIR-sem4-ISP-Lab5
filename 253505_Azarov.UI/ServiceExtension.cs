using _253505_Azarov.UI.Pages;
using _253505_Azarov.UI.ViewModels;

namespace _253505_Azarov.UI;
public static class ServiceExtension
{
    public static IServiceCollection RegisterPages(this IServiceCollection services)
    {
        services
            .AddTransient<ArtistsPage>()
            .AddTransient<SongDetailsPage>()
            .AddTransient<AddOrUpdateSongPage>()
            .AddTransient<AddOrUpdateArtistPage>();
        ;
        return services;
    }   
    
    public static IServiceCollection RegisterViewModels(this IServiceCollection services)
    {
        services
            .AddTransient<ArtistsViewModel>()
            .AddTransient<SongDetailsViewModel>()
            .AddTransient<AddOrUpdateSongViewModel>()
            .AddTransient<AddOrUpdateArtistViewModel>();
        return services;
    }
    public static IServiceCollection CreateImageFolders(this IServiceCollection services)
    {
        string imagesDir =System.IO.Path.Combine(FileSystem.AppDataDirectory, "Images") ;
        string songImagesDir = Path.Combine(FileSystem.AppDataDirectory, "Images", "Songs");
        string artistImagesDir = Path.Combine(FileSystem.AppDataDirectory, "Images", "Artists");
        System.IO.Directory.CreateDirectory(imagesDir);
        System.IO.Directory.CreateDirectory(songImagesDir);
        System.IO.Directory.CreateDirectory(artistImagesDir);
        return services;
    }
}