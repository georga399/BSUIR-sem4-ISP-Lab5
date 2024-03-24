using _253505_Azarov.UI.ViewModels;

namespace _253505_Azarov.UI.Pages;

public partial class AddOrUpdateSongPage : ContentPage
{
    public AddOrUpdateSongPage(AddOrUpdateSongViewModel viewModel)
    {
        InitializeComponent();

        BindingContext = viewModel;
    }
}