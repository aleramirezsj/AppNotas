using AppNotas.Class;
using AppNotas.Models;
using AppNotas.Repositories;
using AppNotas.Utils;
using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppNotas.ViewModels.Peliculas
{
    public class PeliculasViewModel : ObjetoNotificacion
    {
       

        PeliculasRepository peliculasRepository = new PeliculasRepository();

        private bool actividadRealizandose = false;

        public bool ActividadRealizandose
        {
            get { return actividadRealizandose; }
            set
            {
                actividadRealizandose = value;
                OnPropertyChanged();
            }
        }

        private Pelicula peliculaSeleccionada;

        public Pelicula PeliculaSeleccionada
        {
            get { return peliculaSeleccionada; }
            set
            {
                peliculaSeleccionada = value;
                OnPropertyChanged();
                EliminarPeliculaCommand.ChangeCanExecute();
                EditarPeliculaCommand.ChangeCanExecute();
                AgregarPeliculaCommand.ChangeCanExecute();

            }
        }
        private ObservableCollection<Pelicula> peliculas;

        public ObservableCollection<Pelicula> Peliculas
        {
            get { return peliculas; }
            set
            {
                peliculas = value;
                OnPropertyChanged();
            }
        }

        public Command ObtenerPeliculaCommand { get; }
        public Command EditarPeliculaCommand { get; }
        public Command EliminarPeliculaCommand { get; }
        public Command AgregarPeliculaCommand { get; }




        public PeliculasViewModel()
        {
            Peliculas = new ObservableCollection<Pelicula>();
            ObtenerPeliculaCommand = new Command(ObtenerPeliculas);
            EditarPeliculaCommand = new Command(EditarPelicula, PermitirEditar);
            EliminarPeliculaCommand = new Command(EliminarPelicula, PermitirEliminar);
            AgregarPeliculaCommand = new Command(AgregarPelicula);
            ObtenerPeliculas(this);
        }



        private bool PermitirEditar(object arg)
        {
            return peliculaSeleccionada != null;
        }

        private bool PermitirEliminar(object arg)
        {
            return peliculaSeleccionada != null;
        }

        private void AgregarPelicula(object obj)
        {
            WeakReferenceMessenger.Default.Send(new MiMensaje("AbrirNuevoEditarPelicula"));
        }

        private async void EliminarPelicula(object obj)
        {
            bool respuesta = await Application.Current.MainPage.DisplayAlert("Eliminar una pelicula", $"Está seguro que desea eliminar la pelicula {peliculaSeleccionada.nombre}", "Si", "No");
            if (respuesta)
            {
                ActividadRealizandose = true;
                await peliculasRepository.RemoveAsync(peliculaSeleccionada._id);
                ObtenerPeliculas(this);
                ActividadRealizandose = false;
            }
        }

        private void EditarPelicula(object obj)
        {
            WeakReferenceMessenger.Default.Send(new MiMensaje("EditarPelicula") { PeliculaAEditar = PeliculaSeleccionada });
        }

        private async void ObtenerPeliculas(object obj)
        {
            Peliculas.Clear();
            var peliculas = await peliculasRepository.GetAllAsync();
            foreach (var pelicula in peliculas)
            {
                Peliculas.Add(pelicula);
            }
        }
    }
}

