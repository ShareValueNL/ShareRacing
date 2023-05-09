using Microsoft.Extensions.Logging;
using ShareRacing.Data;
using ShareRacing.Data.Interfaces;

namespace ShareRacing;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
			});

		builder.Services.AddMauiBlazorWebView();

#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Logging.AddDebug();
#endif
        builder.Services.AddSingleton<ShareRacingDatabase>();
        builder.Services.AddSingleton<TrackTimeService>();
        builder.Services.AddSingleton<TrackService>();
        builder.Services.AddScoped<IErgastClient, ErgastClient>();

		return builder.Build();
	}
}
