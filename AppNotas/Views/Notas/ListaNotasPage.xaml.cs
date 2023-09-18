using AppNotas.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AppNotas.Views.Notas;

public partial class ListaNotasPage : ContentPage, INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;
    
    private ObservableCollection<Nota> notas;

    public ObservableCollection<Nota> Notas
    {
        get { return notas; }
        set { notas = value;
            //OnPropertyChanged();
        }
    }

    Nota NotaSeleccionada { get; set; }
	Command ObtenerNotasCommand { get;  }
    public ListaNotasPage()
	{
		InitializeComponent();
		Notas = new ObservableCollection<Nota>();
		ObtenerNotasCommand = new Command(ObtenerNotas);
        
	}
    protected override void OnAppearing()
    {
        ObtenerNotas(this);
    }
    private void ObtenerNotas(object obj)
    {
        Notas.Add(new Nota() { Id=1, Titulo="Nota 1", Contenido="texto de la nota 1"});
        NotasListView.ItemsSource = Notas;
    }

    //CallerMemberName nos devuelve el nombre de la propiedad que fue modificada
    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        /*Este código que comprueba si un valor es nulo se puede hacer
        * con una sola linea con la forma ?.Invoke
        if (PropertyChanged != null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }*/
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}