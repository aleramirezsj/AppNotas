using AppNotas.Models;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AppNotas.Views.Notas;

public partial class ListaNotasPage : ContentPage
{    
    public ObservableCollection<Nota> Notas { get; set; }

    //creamos un cliente Http para trabajar con una API desde y hacia internet
    HttpClient clienteHttp = new HttpClient();
    //URL de nuestra API
    string urlApi = "https://webnotasale.azurewebsites.net/api/apinotas";
    Nota NotaSeleccionada { get; set; }
    public ListaNotasPage()
	{
		InitializeComponent();
		Notas = new ObservableCollection<Nota>();

        //configuramos que trabajará con respuestas JSON
        clienteHttp.DefaultRequestHeaders.Add("Accept", "application/json");

        ObtenerNotas(this);
    }
    private async Task ObtenerNotas(object obj)
    {
        var respuesta = await clienteHttp.GetStringAsync(urlApi);
        Notas= JsonConvert.DeserializeObject<ObservableCollection<Nota>>(respuesta);
        
        NotasListView.ItemsSource = Notas;
    }
}