using AppNotas.Class;
using AppNotas.ViewModels.Notas;
using CommunityToolkit.Mvvm.Messaging;

namespace AppNotas.Views.Notas;

public partial class NotasView : ContentPage
{
	public NotasView()
	{
		InitializeComponent();
        WeakReferenceMessenger.Default.Register<MiMensaje>(this, (r, m) =>
        {
            AlRecibirMensaje(m);
        });
    }
    private async void AlRecibirMensaje(MiMensaje m)
    {
        if (m.Value == "AbrirNuevoEditarNota")
        {
            await Navigation.PushAsync(new NuevaEditarNotaView());
        }
        if (m.Value == "EditarNota")
        {
            await Navigation.PushAsync(new NuevaEditarNotaView(m.NotaAEditar));
        }
        if(m.Value == "VolverANotasView")
        {
            await Navigation.PopAsync();
        }
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        var viewmodel = this.BindingContext as NotasViewModel;
        if (viewmodel.NotaSeleccionada != null)
        {
            viewmodel.ObtenerNotas(this);
            viewmodel.NotaSeleccionada = null;
        }
    }
}