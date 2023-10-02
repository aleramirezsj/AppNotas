using AppNotas.Class;
using AppNotas.Models;
using AppNotas.Repositories;
using AppNotas.Utils;
using CommunityToolkit.Mvvm.Messaging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppNotas.ViewModels.Notas
{
    public class NotasViewModel : ObjetoNotificacion
    {
        string urlApi = "https://webnotasale.azurewebsites.net/api/apinotas";

        NotasRepository notasRepository = new NotasRepository();

        private bool actividadRealizandose=false;

        public bool ActividadRealizandose
        {
            get { return actividadRealizandose; }
            set { actividadRealizandose = value;
                OnPropertyChanged();
            }
        }

        private Nota notaSeleccionada;

		public Nota NotaSeleccionada
		{
			get { return notaSeleccionada; }
			set { notaSeleccionada = value; 
				  OnPropertyChanged();
                EliminarNotaCommand.ChangeCanExecute();
                EditarNotaCommand.ChangeCanExecute();
                AgregarNotaCommand.ChangeCanExecute();

            }
		}
		private ObservableCollection<Nota>	notas;

		public ObservableCollection<Nota> Notas
		{
			get { return notas; }
			set { notas = value; 
				OnPropertyChanged();
			}
		}

        public Command ObtenerNotasCommand { get;  }
        public Command EditarNotaCommand { get; }
        public Command EliminarNotaCommand { get; }
        public Command AgregarNotaCommand { get; }




        public NotasViewModel()
        {
			Notas = new ObservableCollection<Nota>();
			ObtenerNotasCommand = new Command(ObtenerNotas);
            EditarNotaCommand = new Command(EditarNota,PermitirEditar);
            EliminarNotaCommand = new Command(EliminarNota, PermitirEliminar);
            AgregarNotaCommand = new Command(AgregarNota);
			ObtenerNotas(this);
        }



        private bool PermitirEditar(object arg)
        {
            return notaSeleccionada != null;
        }

        private bool PermitirEliminar(object arg)
        {
            return notaSeleccionada != null;
        }

        private void AgregarNota(object obj)
        {
            WeakReferenceMessenger.Default.Send(new MiMensaje("AbrirNuevoEditarNota"));
        }

        private async void EliminarNota(object obj)
        {
            bool respuesta=await Application.Current.MainPage.DisplayAlert("Eliminar una nota", $"Está seguro que desea eliminar la nota {notaSeleccionada.Titulo}", "Si","No");
            if (respuesta)
            {
                ActividadRealizandose = true;
                await notasRepository.RemoveAsync(notaSeleccionada.Id);
                ObtenerNotas(this);
                ActividadRealizandose=false;
            }
        }

        private void EditarNota(object obj)
        {
            WeakReferenceMessenger.Default.Send(new MiMensaje("EditarNota") { NotaAEditar=NotaSeleccionada});
        }

        private async void ObtenerNotas(object obj)
        {
            Notas.Clear();
            var notas = await notasRepository.GetAllAsync(); 
            foreach (var nota in notas)
            {
                Notas.Add(nota);
            }
        }
    }
}
