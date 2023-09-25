using AppNotas.Models;

namespace AppNotas.Views.Notas;

public partial class NuevaEditarNotaView : ContentPage
{
	public NuevaEditarNotaView()
	{
		InitializeComponent();
	}

    public NuevaEditarNotaView(Nota notaAEditar)
    {
        InitializeComponent();
        lblTitulo.Text = notaAEditar.Titulo;
        lblContenido.Text = notaAEditar.Contenido;
    }
}