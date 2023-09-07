
using AppNotas.Views.Flyout;

namespace AppNotas;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new EjemploFlyoutPage();
	}
}
