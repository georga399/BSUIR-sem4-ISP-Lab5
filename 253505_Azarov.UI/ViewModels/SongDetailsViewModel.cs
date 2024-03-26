using Android.Accessibilityservice.AccessibilityService;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using _253505_Azarov.Application.SongUseCases.Commands;
using _253505_Azarov.UI.Pages;
using _253505_Azarov.Application.SongUseCases;
using _253505_Azarov.Application.SongUseCases.Queries;
namespace _253505_Azarov.UI.ViewModels;

[QueryProperty("Song", "Song")]
public partial class SongDetailsViewModel: ObservableObject
{
    private readonly IMediator _mediator;
    public SongDetailsViewModel(IMediator mediator)
    {
        _mediator = mediator;
    }
    [ObservableProperty]
    Song song;

    [ObservableProperty]
    string songTitle;
    [ObservableProperty]
    string songDescription;
    [ObservableProperty]
    int songPosition;
    [ObservableProperty]
    string songGenre;
    [ObservableProperty]
    string songArtistName;
    [ObservableProperty]
    int songId;
    [RelayCommand]
    async void GetSongById()
    {
        Song = await _mediator.Send(new GetSongByIdQuery(Song.Id));
        if(Song is null)
            return;
        SongTitle = Song.Title;    
        SongDescription = Song.Description;
        SongPosition = Song.Position;
        SongGenre = Song.Genre;
        SongArtistName = Song.Artist.Name;
        // SongId = Song.Id;
    }

    [RelayCommand]
    async Task UpdateSong() => 
        await GotoAddOrUpdatePage<AddOrUpdateSongPage>(new UpdateSongCommand(){Song = Song});
    
    private async Task GotoAddOrUpdatePage<Page>(IAddOrUpdateSongRequest request)
        where Page : ContentPage
    {
        IDictionary<string, object> parameters = 
        new Dictionary<string, object>() 
        { 
            { "Request", request },
            {"Artist", request.Song.Artist!}
        };
        await Shell.Current
            .GoToAsync(nameof(AddOrUpdateSongPage), parameters);
    }
    [RelayCommand]
    async Task DeleteSong() => 
        await RemoveSong(Song);
    private async Task RemoveSong(Song song)
    {
        await _mediator.Send(new DeleteSongCommand(song));
        await Shell.Current.GoToAsync("..");
    }
    
}