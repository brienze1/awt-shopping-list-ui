using ShoppingList.Service;
using ShoppingList.View;
using ShoppingList.ViewModel;
using Microsoft.Extensions.Logging;

namespace awt_shopping_list_ui;

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
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif

        builder.Services.AddSingleton<UserService>();
        builder.Services.AddSingleton<LoginViewModel>();
        builder.Services.AddSingleton<CreateUserViewModel>();
        builder.Services.AddSingleton<UserHomeViewModel>();
        builder.Services.AddSingleton<LoginPage>();
        builder.Services.AddTransient<CreateUserPage>();
        builder.Services.AddTransient<UserHomePage>();

		return builder.Build();
	}
}

