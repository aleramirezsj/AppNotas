using AppNotas.Models;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace AppNotas.Views.Peliculas;

public partial class ListaPeliculasPage : ContentPage
{
    public ObservableCollection<Pelicula> Peliculas { get; set; }

    //creamos un cliente Http para trabajar con una API desde y hacia internet
    HttpClient clienteHttp = new HttpClient();
    //URL de nuestra API
    string urlApi = "https://practprof2023-2855.restdb.io/rest/peliculas";
    Nota PeliculaSeleccionada { get; set; }
    public ListaPeliculasPage()
    {
        InitializeComponent();
        Peliculas = new ObservableCollection<Pelicula>();

        //configuramos que trabajará con respuestas JSON
        clienteHttp.DefaultRequestHeaders.Add("Accept", "application/json");
        clienteHttp.DefaultRequestHeaders.Add("x-apikey", "6466d9870b60fc42f4e197bf");
        ObtenerPeliculas(this);
    }
    private async Task ObtenerPeliculas(object obj)
    {
        var respuesta = await clienteHttp.GetStringAsync(urlApi);
        Peliculas = JsonConvert.DeserializeObject<ObservableCollection<Pelicula>>(respuesta);

        PeliculasListView.ItemsSource = Peliculas;
    }
}