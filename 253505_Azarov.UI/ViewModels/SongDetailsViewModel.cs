using Android.Accessibilityservice.AccessibilityService;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using _253505_Azarov.Application.SongUseCases.Commands;
using _253505_Azarov.UI.Pages;
using _253505_Azarov.Application.SongUseCases;
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