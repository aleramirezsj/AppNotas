using AppNotas.Models;
using AppNotas.ViewModels.Notas;

namespace AppNotas.Views.Notas;

public partial class NuevaEditarNotaView : ContentPage
{
    NuevoEditarNotaViewModel NuevoEditarNotaViewModel { get; set; }
	public NuevaEditarNotaView()
	{
		InitializeComponent();
	}

    public NuevaEditarNotaView(Nota notaAEditar)
    {
        InitializeComponent();
        NuevoEditarNotaViewModel=this.BindingContext as NuevoEditarNotaViewModel;
        NuevoEditarNotaViewModel.NotaEditada=notaAEditar;
        NuevoEditarNotaViewModel.CargarDatosEnPantalla();
        
    }
}