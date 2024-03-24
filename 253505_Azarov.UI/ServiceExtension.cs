using _253505_Azarov.UI.Pages;
using _253505_Azarov.UI.ViewModels;

namespace _253505_Azarov.UI;
public static class ServiceExtension
{
    public static IServiceCollection RegisterPages(this IServiceCollection services)
    {
        services
            .AddSingleton<ArtistsPage>()
            .AddTransient<SongDetailsPage>()
            .AddTransient<AddOrUpdateSongPage>()
            .AddTransient<AddOrUpdateArtistPage>();
        ;
        return services;
    }   
    
    public static IServiceCollection RegisterViewModels(this IServiceCollection services)
    {
        services
            .AddSingleton<ArtistsViewModel>()
            .AddTransient<SongDetailsViewModel>()
            .AddTransient<AddOrUpdateSongViewModel>()
            .AddTransient<AddOrUpdateArtistViewModel>();
        return services;
    }
}