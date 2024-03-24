using _253505_Azarov.UI.Pages;

namespace _253505_Azarov.UI;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute(nameof(SongDetailsPage),
            typeof(SongDetailsPage));
        Routing.RegisterRoute(nameof(AddOrUpdateSongPage),
            typeof(AddOrUpdateSongPage));
        Routing.RegisterRoute(nameof(AddOrUpdateArtistPage),
            typeof(AddOrUpdateArtistPage));
    }
}