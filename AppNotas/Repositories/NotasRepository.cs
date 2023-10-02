using AppNotas.Models;
using AppNotas.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppNotas.Repositories
{
    public class NotasRepository
    {
        const string Url = "https://webnotasale.azurewebsites.net/api/apinotas";

        /// <summary>
        /// Método que agrega una nota de manera asincrónica
        /// </summary>
        /// <param name="titulo"></param>
        /// <param name="contenido"></param>
        /// <returns></returns>
        public async Task<Nota> AddAsync(string titulo, string contenido)
        {
            //creamos un objeto del tipo Nota con los parámetros que llegan
            Nota nota = new Nota()
            {
                Titulo = titulo,
                Contenido = contenido
            };

            //creamos un objeto HttpClient
            HttpClient client = Helper.ObtenerClienteHttp();

            //enviamos por POST el objeto que creamos a la URL de la API
            var response = await client.PostAsync(Url,
                new StringContent(
                    JsonConvert.SerializeObject(nota),
                    Encoding.UTF8, "application/json"));

            //retorna el objeto que se agregó en la API ya con su ID generado por la base de datos
            return JsonConvert.DeserializeObject<Nota>(
                await response.Content.ReadAsStringAsync());
        }

        public async Task<bool> RemoveAsync(int id)
        {
            HttpClient client = Helper.ObtenerClienteHttp();
            var response = await client.DeleteAsync(Url + "/" + id);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateAsync(string titulo, string contenido, int id)
        {
            HttpClient client = Helper.ObtenerClienteHttp();
            Nota nota = new Nota()
            {
                Id = id,
                Titulo = titulo,
                Contenido = contenido,
            };
            var response = await client.PutAsync(Url + "/" + id, new StringContent(JsonConvert.SerializeObject(nota), Encoding.UTF8, "application/json"));
            return response.IsSuccessStatusCode;
        }

        public async Task<IEnumerable<Nota>> GetAllAsync()
        {
            HttpClient client = Helper.ObtenerClienteHttp();
            var response = await client.GetStringAsync(Url);
            return JsonConvert.DeserializeObject<IEnumerable<Nota>>(response);
        }

        public async Task<Nota> GetById(int id)
        {
            HttpClient client = Helper.ObtenerClienteHttp();
            var response = await client.GetStringAsync($"{Url}/{id}");
            return JsonConvert.DeserializeObject<Nota>(response);
        }


    }
}
