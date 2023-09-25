using AppNotas.Models;
using AppNotas.Utils;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace AppNotas.Views.Peliculas;

public partial class ListaPeliculasPage : ContentPage
{
    public ObservableCollection<Pelicula> Peliculas { get; set; }

    //URL de nuestra API
    string urlApi = "https://practprof2023-2855.restdb.io/rest/peliculas";
    Nota PeliculaSeleccionada { get; set; }
    public ListaPeliculasPage()
    {
        InitializeComponent();
        Peliculas = new ObservableCollection<Pelicula>();
        ObtenerPeliculas(this);
    }
    private async Task ObtenerPeliculas(object obj)
    {
        var clienteHttp = Helper.ObtenerClienteHttp("6466d9870b60fc42f4e197bf");
        var respuesta = await clienteHttp.GetStringAsync(urlApi);
        Peliculas = JsonConvert.DeserializeObject<ObservableCollection<Pelicula>>(respuesta);

        PeliculasListView.ItemsSource = Peliculas;
    }
}