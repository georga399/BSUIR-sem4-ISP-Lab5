namespace _253505_Azarov.UI;

public partial class App : Microsoft.Maui.Controls.Application 
{
    public App()
    {
        InitializeComponent();

        MainPage = new AppShell();
    }
}