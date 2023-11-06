using Firebase.Auth;
using Firebase.Auth.Providers;
using Firebase.Auth.Repository;
using System.Diagnostics;
using System;
using System.Threading.Tasks;

namespace AppNotas.Views.Notas;

public partial class IniciarSesionView : ContentPage
{
	private readonly FirebaseAuthClient _clientAuth;
    private FileUserRepository _userRepository;
    private UserInfo _userInfo;
    private FirebaseCredential _firebaseCredential;
    public IniciarSesionView(FirebaseAuthClient firebaseAuthClient)
	{
		InitializeComponent();
		_clientAuth = firebaseAuthClient;
        _userRepository = new FileUserRepository("AppNotas");
        
        ChequearSiHayUsuarioAlmacenado();
	}

    private async void ChequearSiHayUsuarioAlmacenado()
    {
        if(_userRepository.UserExists())
        {
            (_userInfo, _firebaseCredential) =_userRepository.ReadUser();
            txtEmail.Text= _userInfo.Email;
            txtPassword.Text= _userInfo.Uid.ToString();
            await Navigation.PushAsync(new NotasView());
        }
    }

    private async void btnIniciarSesion_Clicked(object sender, EventArgs e)
    {
		try
		{
            
            var userCredential=await _clientAuth.SignInWithEmailAndPasswordAsync(txtEmail.Text, txtPassword.Text);

            if (chkRecordarContraseña.IsChecked)
            {
                _userRepository.SaveUser(userCredential.User);
            }else
            {
                _userRepository.DeleteUser();
            }

            await Navigation.PushAsync(new NotasView());

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

    private async void btnLoginGoogle_Clicked(object sender, EventArgs e)
    {
        // sign in via web browser redirect - navigate to given uri, monitor a redirect to 
        // your authdomain.firebaseapp.com/__/auth/handler
        // and return the whole redirect uri back to the client;
        // this method is actually used by FirebaseUI
        var url = "https://chatisp20.firebaseapp.com/__/auth/handler";
        var provider = new GoogleProvider();

        WebAuthenticatorResult authResult = await WebAuthenticator.Default.AuthenticateAsync(
        new WebAuthenticatorOptions()
        {
            Url = new Uri(url),
            CallbackUrl = new Uri("AppNotas://callback"),
            PrefersEphemeralWebBrowserSession = true
        });

        string accessToken = authResult?.AccessToken;

        var userCredential = await _clientAuth.SignInWithRedirectAsync(provider.ProviderType, async url =>
        {
            Uri uri = new Uri(url);
            var response=await Browser.Default.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
            return "";
        });
        //string a = "";
    }
}
