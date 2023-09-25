using AppNotas.Models;
using AppNotas.Utils;
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

        private Nota notaSeleccionada;

		public Nota NotaSeleccionada
		{
			get { return notaSeleccionada; }
			set { notaSeleccionada = value; 
				  OnPropertyChanged();
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

        public NotasViewModel()
        {
			Notas = new ObservableCollection<Nota>();
			ObtenerNotasCommand = new Command(ObtenerNotas);
        }

        private async void ObtenerNotas(object obj)
        {
            var clienteHttp = Helper.ObtenerClienteHttp();
            var respuesta = await clienteHttp.GetStringAsync(urlApi);
            Notas = JsonConvert.DeserializeObject<ObservableCollection<Nota>>(respuesta); 
        }
    }
}
