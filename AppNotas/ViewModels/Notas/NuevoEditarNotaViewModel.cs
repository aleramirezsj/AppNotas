using AppNotas.Class;
using AppNotas.Models;
using AppNotas.Repositories;
using AppNotas.Utils;
using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppNotas.ViewModels.Notas
{
    public class NuevoEditarNotaViewModel : ObjetoNotificacion
    {
        NotasRepository notasRepository=new NotasRepository();
        public Nota NotaEditada { get; set; }

        private string titulo;

		public string Titulo
		{
			get { return titulo; }
			set { titulo = value;
				OnPropertyChanged();
			}
		}
		private string contenido;

		public string Contenido
		{
			get { return contenido; }
			set { contenido = value;
				OnPropertyChanged();
			}
		}

        public Command GuardarCommand { get;  }
        public Command CancelarCommand { get; }

        public NuevoEditarNotaViewModel()
        {
			GuardarCommand = new Command(Guardar);
			CancelarCommand = new Command(Cancelar);
        }

        private void Cancelar(object obj)
        {
            WeakReferenceMessenger.Default.Send(new MiMensaje("VolverANotasView"));
        }

        private async void Guardar(object obj)
        {
            if(NotaEditada==null)
            {
                Nota nota=await notasRepository.AddAsync(titulo, contenido);
                Debug.Print(">>>>>>>>>>>> AGREGANDO UNA NOTA");
                Debug.Print(nota.ToString());
            } else
            {
                await notasRepository.UpdateAsync(titulo, contenido, NotaEditada.Id);
            }
            WeakReferenceMessenger.Default.Send(new MiMensaje("VolverANotasView"));
        }

        public void CargarDatosEnPantalla()
        {
            Titulo = NotaEditada.Titulo;
            Contenido = NotaEditada.Contenido;
        }
    }
}
