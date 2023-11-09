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
        public byte[] Imagen { get; set; }

        private ImageSource foto;


        public ImageSource Foto
        {
            get { return foto; }
            set { foto = value; 
                OnPropertyChanged();
            }
        }

        public Command CapturarFotoCommand { get;  }
        public Command GuardarCommand { get;  }
        public Command CancelarCommand { get; }

        public NuevoEditarNotaViewModel()
        {
			GuardarCommand = new Command(Guardar);
			CancelarCommand = new Command(Cancelar);
            CapturarFotoCommand = new Command(CapturarFoto);
        }

        private async void CapturarFoto(object obj)
        {
            if (MediaPicker.Default.IsCaptureSupported)
            {
                FileResult photo = await MediaPicker.Default.CapturePhotoAsync().ConfigureAwait(true);
                if(photo != null) { 
                    Foto = ImageSource.FromStream(() => photo.OpenReadAsync().Result);
                    Imagen=await Helper.ConvertImageSourceToBytesAsync(Foto);
                }
                
            }
        }
        private void Cancelar(object obj)
        {
            WeakReferenceMessenger.Default.Send(new MiMensaje("VolverANotasView"));
        }

        private async void Guardar(object obj)
        {
            if(NotaEditada==null)
            {
                Nota nota=await notasRepository.AddAsync(titulo, contenido,Imagen);
            } else
            {
                await notasRepository.UpdateAsync(titulo, contenido, Imagen,NotaEditada.Id);
            }
            WeakReferenceMessenger.Default.Send(new MiMensaje("VolverANotasView"));
        }

        public void CargarDatosEnPantalla()
        {
            Titulo = NotaEditada.Titulo;
            Contenido = NotaEditada.Contenido;
            Imagen = NotaEditada.Imagen;
            if(NotaEditada.Imagen!=null && NotaEditada.Imagen!=Array.Empty<byte>())
                Foto=Helper.convertirBytesAImagen(NotaEditada.Imagen);
        }
    }
}
