using Firebase.Auth;
using Firebase.Auth.Providers;
using Microsoft.Extensions.Logging;

namespace AppNotas;

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

		//creamos la inyección de dependecias que habilita la posibilidad de instanciar en cualquier constructor, que pueda recibir por parámetros una instancia de FirebaseAuthClient
		builder.Services.AddSingleton(new FirebaseAuthClient(new FirebaseAuthConfig()
		{
			ApiKey= "AIzaSyAF2Z82tKP2taHAv4vK0FMmqQOqhy9ge_c",
			AuthDomain= "chatisp20.firebaseapp.com",
			Providers= new FirebaseAuthProvider[]
			{
				new EmailProvider()			}
        }));
#endif

		return builder.Build();
	}
}
