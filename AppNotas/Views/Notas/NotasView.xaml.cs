using AppNotas.Class;
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
    }
}