using AppNotas.Models;
using AppNotas.ViewModels.Notas;

namespace AppNotas.Views.Notas;

public partial class NuevaEditarNotaView : ContentPage
{
    NuevoEditarNotaViewModel NuevoEditarNotaViewModel { get; set; }
	public NuevaEditarNotaView()
	{
		InitializeComponent();
	}

    public NuevaEditarNotaView(Nota notaAEditar)
    {
        InitializeComponent();
        NuevoEditarNotaViewModel=this.BindingContext as NuevoEditarNotaViewModel;
        NuevoEditarNotaViewModel.NotaEditada=notaAEditar;
        NuevoEditarNotaViewModel.CargarDatosEnPantalla();
        
    }

    private async void btnTomarFoto_Clicked(object sender, EventArgs e)
    {
        if (MediaPicker.Default.IsCaptureSupported)
        {
            FileResult photo = await MediaPicker.Default.CapturePhotoAsync().ConfigureAwait(true);

            ImageSource imageSource = ImageSource.FromStream(() => photo.OpenReadAsync().Result);
            ControlImagen.Source = imageSource;
            //if (photo != null)
            //{
            //    // save the file into local storage
            //    string localFilePath = Path.Combine(FileSystem.CacheDirectory, photo.FileName);

            //    using Stream sourceStream = await photo.OpenReadAsync();
            //    using FileStream localFileStream = File.OpenWrite(localFilePath);

            //    await sourceStream.CopyToAsync(localFileStream);
            //}
        }
    }
}