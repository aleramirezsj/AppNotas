using AppNotas.Class;
using AppNotas.ViewModels.Notas;
using CommunityToolkit.Mvvm.Messaging;
using Firebase.Auth.Repository;

namespace AppNotas.Views.Notas;

public partial class NotasView : ContentPage
{
    private FileUserRepository _userRepository;
    public NotasView()
	{
		InitializeComponent();

        _userRepository = new FileUserRepository("AppNotas");

        //código para preparar la recepción de mensajes y la llamada al método RecibirMensaje
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
        //if (viewmodel.NotaSeleccionada != null)
        //{
            viewmodel.ObtenerNotas(this);
            viewmodel.NotaSeleccionada = null;
        //}
    }

    private void btnCerrarSesion_Clicked(object sender, EventArgs e)
    {
        _userRepository.DeleteUser();
        Navigation.PopAsync();
    }
}