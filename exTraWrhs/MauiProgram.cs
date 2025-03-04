using exTraWrhs.Services.Navigation;
using exTraWrhs.Services.Preferences;
using exTraWrhs.ViewModels;
using exTraWrhs.Views;
using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;

namespace exTraWrhs;

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

		builder.Services.AddSingleton<INavigationService, NavigationService>();
		builder.Services.AddSingleton<IPreferencesService, PreferencesService>();

		builder.Services.AddTransient<MainView>();
		builder.Services.AddTransient<PrikupljanjeView>();
        builder.Services.AddTransient<PakiranjeView>();
        builder.Services.AddTransient<InventuraView>();
        builder.Services.AddTransient<ZapisnikView>();
        builder.Services.AddTransient<OsnovnaSredstvaView>();
        builder.Services.AddTransient<StanjeView>();
        builder.Services.AddTransient<EMVSView>();
        builder.Services.AddTransient<AdministracijaView>();

        builder.Services.AddSingleton<MainViewModel>();
        builder.Services.AddSingleton<PrikupljanjeViewModel>();
        builder.Services.AddSingleton<PakiranjeViewModel>();
        builder.Services.AddSingleton<InventuraViewModel>();
        builder.Services.AddSingleton<ZapisnikViewModel>();
        builder.Services.AddSingleton<OsnovnaSredstvaViewModel>();
        builder.Services.AddTransient<StanjeViewModel>();
        builder.Services.AddTransient<EMVSViewModel>();
        builder.Services.AddTransient<AdministracijaViewModel>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
