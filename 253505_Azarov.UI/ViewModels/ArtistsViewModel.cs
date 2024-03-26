using System.Collections.ObjectModel;
using _253505_Azarov.Application.ArtistUseCases.Commands;
using _253505_Azarov.Application.ArtistUseCases.Queries;
using _253505_Azarov.Application.SongUseCases;
using _253505_Azarov.Application.SongUseCases.Commands;
using _253505_Azarov.Application.SongUseCases.Queries;
using _253505_Azarov.UI.Pages;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
namespace _253505_Azarov.UI.ViewModels;
public partial class ArtistsViewModel: ObservableObject
{
    private readonly IMediator _mediator;
    public ArtistsViewModel(IMediator mediator)
    {
        _mediator = mediator;
    }
    public ObservableCollection<Artist> Artists { get; set; } = new();
    public ObservableCollection<Song> Songs { get; set; } = new();
    
    [ObservableProperty]
    Artist selectedArtist = new(); 
    [ObservableProperty]
    Song selectedSong = new();
    [ObservableProperty]
    int songsCount;
    [ObservableProperty]
    string errorText;
    
    [RelayCommand]
    async Task UpdateArtistsList() => await GetArtists();

    [RelayCommand]
    async Task UpdateSongsList() => await GetSongs();

    [RelayCommand]
    async Task ShowDetails(Song song) => await GotoDetailsPage(song);
    private async Task GotoDetailsPage(Song song)
    {
        IDictionary<string, object> parameters = 
        new Dictionary<string, object>() 
        { 
            { "Song", song } 
        };
        await Shell.Current
            .GoToAsync(nameof(SongDetailsPage), parameters);
    }
    [RelayCommand]
    private async Task AddArtist()
    {
        await GotoAddOrUpdatePage(nameof(AddOrUpdateArtistPage), new AddArtistCommand(){Artist = new Artist()});
    } 

    [RelayCommand]
    private async Task UpdateArtist()  
    {
        if(SelectedArtist is null)
            return;
        await GotoAddOrUpdatePage(nameof(AddOrUpdateArtistPage), new UpdateArtistCommand(){Artist = SelectedArtist});
    }



    [RelayCommand]
    private async Task AddSong()
    {
        if(SelectedArtist is null)
            return;
        await GotoAddOrUpdatePage(nameof(AddOrUpdateSongPage), new AddSongCommand(){Song = new Song()});
    }
    private async Task GotoAddOrUpdatePage(string route, IRequest request)
    {
        IDictionary<string, object> parameters = 
            new Dictionary<string, object>() 
            { 
                { "Request", request },
                { "Artist", SelectedArtist }
            };
        await Shell.Current
            .GoToAsync(route, parameters);
    }

    [RelayCommand]
    private async Task DeleteArtist()
    {
        if(SelectedArtist is null)
            return;
        await DeleteArtistAction();
    }
    private async Task DeleteArtistAction() //TODO: Update page
    {
        await _mediator.Send(new DeleteArtistCommand(SelectedArtist));
        await GetArtists();
    }
    public async Task GetArtists()
    {
        var artists = await _mediator.Send(new GetArtistsQuery());
        await MainThread.InvokeOnMainThreadAsync(() =>
        {
            Artists.Clear();
            foreach (var artist in artists)
                Artists.Add(artist);
        });
    }
    public async Task GetSongs()
    {
        if(SelectedArtist is null)
        {
            Songs.Clear();
            return;
        }
        var songs = await _mediator.Send(new
        GetSongsByArtistIdQuery(SelectedArtist.Id));
        await MainThread.InvokeOnMainThreadAsync(() =>
        {
            Songs.Clear();
            foreach (var song in songs)
                Songs.Add(song);
            SongsCount = Songs.Count;
        });
    }
}
