
using CommunityToolkit.Maui;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using TextesMaui.Data;
using TextesMaui.PdfsRelatorios;
using TextesMaui.Services;
using TextesMaui.ViewModel;

namespace TextesMaui;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        builder.Services.AddDbContext<AppgeContext>(
            options => options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
            new MySqlServerVersion(new Version(9, 3, 0))));

        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddSingleton<MainViewModel>();

        builder.Services.AddSingleton<ScoolDbService>();
        builder.Services.AddSingleton<RelatorioAlunosDivida>();


#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
