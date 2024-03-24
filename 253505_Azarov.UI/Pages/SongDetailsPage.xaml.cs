using _253505_Azarov.UI.ViewModels;

namespace _253505_Azarov.UI.Pages;

public partial class SongDetailsPage : ContentPage
{
    public SongDetailsPage(SongDetailsViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}