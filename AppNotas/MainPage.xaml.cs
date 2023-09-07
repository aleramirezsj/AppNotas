namespace AppNotas;

public partial class MainPage : ContentPage
{
	int contador = 0;

	public MainPage()
	{
		InitializeComponent();
	}

	private void OnBotonPulsado(object sender, EventArgs e)
	{
		contador++;

		if (contador == 1)
			CounterBtn.Text = $"Presionado {contador} vez";
		else
			CounterBtn.Text = $"Presionado {contador} veces";

		SemanticScreenReader.Announce(CounterBtn.Text);
	}
}

