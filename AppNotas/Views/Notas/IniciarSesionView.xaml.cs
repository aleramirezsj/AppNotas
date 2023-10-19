using Firebase.Auth;

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
            await _clientAuth.SignInWithEmailAndPasswordAsync(txtUsuario.Text, txtPassword.Text);
			await Application.Current.MainPage.DisplayAlert("Inicio de sesión", "Bienvenido", "Ok");
        }
		catch (Exception)
		{
            await Application.Current.MainPage.DisplayAlert("Inicio de sesión", "Ocurrió un problema", "Ok");
            
		}
        
    }
}