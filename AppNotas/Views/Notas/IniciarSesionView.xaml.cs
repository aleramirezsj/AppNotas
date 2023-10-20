using Firebase.Auth;
using System.Threading.Tasks;

namespace AppNotas.Views.Notas;

public partial class IniciarSesionView : ContentPage
{
	private readonly FirebaseAuthClient _clientAuth;
	public IniciarSesionView(FirebaseAuthClient firebaseAuthClient)
	{
		InitializeComponent();
		_clientAuth = firebaseAuthClient;
	}

    private async void btnIniciarSesion_Clicked(object sender, EventArgs e)
    {
		try
		{
            await _clientAuth.SignInWithEmailAndPasswordAsync(txtEmail.Text, txtPassword.Text);
			await Application.Current.MainPage.DisplayAlert("Inicio de sesión", "Bienvenido", "Ok");
        }
        catch (FirebaseAuthException error)
		{
            await Application.Current.MainPage.DisplayAlert("Inicio de sesión", "Ocurrió un problema:" + error.Reason, "Ok");
            
		}
        
    }

    private async void btnRegistrarse_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CrearCuentaView(_clientAuth));
    }
}