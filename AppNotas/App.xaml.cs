
using AppNotas.Class;
using AppNotas.Views.Flyout;
using AppNotas.Views.Notas;
using AppNotas.Views.Peliculas;
using AppNotas.Views.Retos;
using AppNotas.Views.TabbedPages;
using CommunityToolkit.Mvvm.Messaging;
using Firebase.Auth;

namespace AppNotas;

public partial class App : Application
{
	public App(FirebaseAuthClient firebaseAuthClient)
	{
		InitializeComponent();

		//MainPage = new NavigationPage(new IniciarSesionView(firebaseAuthClient));
		MainPage = new EjemploFlyoutPage();


    }


}
