using System.Collections.ObjectModel;
using _253505_Azarov.Application.ArtistUseCases.Queries;
using _253505_Azarov.Application.SongUseCases;
using _253505_Azarov.Application.SongUseCases.Commands;
using _253505_Azarov.Domain.Entities;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Storage;

namespace _253505_Azarov.UI.ViewModels;
public partial class AddOrUpdateSongViewModel : ObservableObject, IQueryAttributable
{
    private readonly IMediator _mediator;
    public AddOrUpdateSongViewModel(IMediator mediator)
    {
        _mediator = mediator;
    }
    [ObservableProperty]
    string errText;
    [ObservableProperty]
    Artist artist = new();

    [ObservableProperty]
    FileResult image;
    [ObservableProperty]
    IAddOrUpdateSongRequest request;
    public ObservableCollection<Artist> Artists { get; set; } = new();

    [RelayCommand]
    public async void PickImage()
    {
        var customFileType = new FilePickerFileType(
            new Dictionary<DevicePlatform, IEnumerable<string>>
            {
                { DevicePlatform.Android, new[] { ".png" } }, 
            });

        PickOptions options = new()
        {
            PickerTitle = "Please select a png image",
            FileTypes = customFileType,
        };

        try
        {
            var result = await FilePicker.Default.PickAsync(options);
            if (result != null)
            {
                if (result.FileName.EndsWith(".png", StringComparison.OrdinalIgnoreCase))
                {
                    Image = result;
                }
            }
        }

        catch (Exception ex)
        {
            return;
        }

        return;
    }

    [RelayCommand]
    async Task AddOrUpdateSong()
    {
        await Task.Delay(1);
        if (
            Request.Song.Title is null ||
            Request.Song.Title == string.Empty ||
            Request.Song.Description is null ||
            Request.Song.Description == string.Empty
            )
        {
            return;
        }

        Request.Song.Artist = Artist;

        
        await _mediator.Send(Request);

        if (Image != null)
        {
            using var stream = await Image.OpenReadAsync();
            var image = ImageSource.FromStream(() => stream);

            string filename = Path.Combine(Preferences.Default.Get<string>("LocalData", null), $"{Request.Song.Id}.png");

            using var fileStream = File.Create(filename);
            stream.Seek(0, SeekOrigin.Begin);
            stream.CopyTo(fileStream);
            stream.Seek(0, SeekOrigin.Begin);
        }
        

        await Shell.Current.GoToAsync("..");
    }
    [RelayCommand]
    async Task UpdateArtistsList() => await GetArtists();
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
    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        Request = query["Request"] as IAddOrUpdateSongRequest;
        Artist = query["Artist"] as Artist;
    }
}
