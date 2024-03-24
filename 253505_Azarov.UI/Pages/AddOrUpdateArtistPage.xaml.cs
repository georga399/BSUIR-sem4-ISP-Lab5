using _253505_Azarov.UI.ViewModels;

namespace _253505_Azarov.UI.Pages;

public partial class AddOrUpdateArtistPage : ContentPage
{
    public AddOrUpdateArtistPage(AddOrUpdateArtistViewModel viewModel)
    {
        InitializeComponent();

        BindingContext = viewModel;
    }
}