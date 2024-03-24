using System.Collections.ObjectModel;
using _253505_Azarov.Application.ArtistUseCases.Commands;
using _253505_Azarov.Application.ArtistUseCases.Queries;
using _253505_Azarov.Application.SongUseCases;
using _253505_Azarov.Application.SongUseCases.Commands;
using _253505_Azarov.Domain.Entities;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Storage;

namespace _253505_Azarov.UI.ViewModels;
public partial class AddOrUpdateArtistViewModel : ObservableObject, IQueryAttributable
{
    private readonly IMediator _mediator;
    public AddOrUpdateArtistViewModel(IMediator mediator)
    {
        _mediator = mediator;
    }
    [ObservableProperty]
    private IAddOrUpdateArtistRequest request;

    [ObservableProperty]
    FileResult image;

    [RelayCommand]
    public async Task PickImage()
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
    async Task AddOrUpdateArtist()
    {
        await _mediator.Send(Request);
        
        await Shell.Current.GoToAsync("..");
    }
    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        Request = query["Request"] as IAddOrUpdateArtistRequest;
    }
}

