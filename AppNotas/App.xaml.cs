
using AppNotas.Views.Flyout;
using AppNotas.Views.TabbedPages;

namespace AppNotas;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new EjemploTabbedPage();
	}
}
