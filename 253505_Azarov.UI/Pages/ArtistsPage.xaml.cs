using _253505_Azarov.UI.ViewModels;
namespace _253505_Azarov.UI.Pages;

public partial class ArtistsPage : ContentPage
{

    public ArtistsPage(ArtistsViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

}