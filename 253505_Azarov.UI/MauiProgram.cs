using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using _253505_Azarov.Application;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using _253505_Azarov.Persistense.Data;

namespace _253505_Azarov.UI;
public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        string settingsStream = "253505_Azarov.UI.appsettings.json";
        
        var builder = MauiApp.CreateBuilder();
        
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("FontAwesome.ttf", "FontAwesome");
            });

        // var a = Assembly.GetExecutingAssembly();
        // using Stream stream = a.GetManifestResourceStream(settingsStream);
        // builder.Configuration.AddJsonStream(stream);

        // var connStr = builder.Configuration
        //     .GetConnectionString("SqliteConnection");

        var connStr = " Data Source = {0}sqlite.db";
        string dataDirectory = FileSystem.Current.AppDataDirectory + "/";
        connStr = String.Format(connStr, dataDirectory);
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseSqlite(connStr)
            .Options;

        builder.Services
            .AddApplication()
            .AddPersistense(options)
            .RegisterPages()
            .RegisterViewModels()
            .CreateImageFolders();

#if DEBUG
        builder.Logging.AddDebug();
#endif
        DbInitializer
            .Initialize(builder.Services.BuildServiceProvider())
            .Wait();

        return builder.Build();
        
    }
}