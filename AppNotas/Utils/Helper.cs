using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace AppNotas.Utils
{
    public class Helper
    {
        public static HttpClient ObtenerClienteHttp()
        {
            HttpClient client = new HttpClient();
            //configuramos que trabajará con respuestas JSON
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            return client;
        }
        public static HttpClient ObtenerClienteHttp(string apikey)
        {
            HttpClient client = new HttpClient();
            //configuramos que trabajará con respuestas JSON
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("x-apikey", apikey);
            return client;
        }
        public static ImageSource convertirBytesAImagen(Byte[] arregloImg)
        {
            MemoryStream imagenStream = new MemoryStream(arregloImg);
            ImageSource imagen = ImageSource.FromStream(()=>(Stream)imagenStream);
            
            return imagen;
        }

        public async static Task<byte[]> convertirImagenABytes(FileResult img)
        {
            byte[] imagenBytes;
            string localFilePath = Path.Combine(FileSystem.CacheDirectory, img.FileName);
            using Stream stream = await img.OpenReadAsync();
            using (FileStream localFileStream = File.OpenWrite(localFilePath))
            {

                await stream.CopyToAsync(localFileStream);
            }
            imagenBytes = File.ReadAllBytes(localFilePath);

            return imagenBytes;
        }

    }
}
