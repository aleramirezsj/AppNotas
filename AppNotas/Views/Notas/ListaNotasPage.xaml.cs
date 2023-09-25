using AppNotas.Models;
using AppNotas.Utils;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AppNotas.Views.Notas;

public partial class ListaNotasPage : ContentPage
{    
    public ObservableCollection<Nota> Notas { get; set; }
    //URL de nuestra API
    string urlApi = "https://webnotasale.azurewebsites.net/api/apinotas";
    Nota NotaSeleccionada { get; set; }
    public ListaNotasPage()
	{
		InitializeComponent();
		Notas = new ObservableCollection<Nota>();
        ObtenerNotas(this);
    }
    private async Task ObtenerNotas(object obj)
    {
        var clienteHttp = Helper.ObtenerClienteHttp();
        var respuesta = await clienteHttp.GetStringAsync(urlApi);
        Notas= JsonConvert.DeserializeObject<ObservableCollection<Nota>>(respuesta);
        
        NotasListView.ItemsSource = Notas;
    }
}