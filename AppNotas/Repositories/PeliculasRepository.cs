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
    public class PeliculasRepository
    {
        const string Url = "https://practprof2023-2855.restdb.io/rest/peliculas";
        //creamos un objeto HttpClient
        HttpClient client = Helper.ObtenerClienteHttp("6466d9870b60fc42f4e197bf");

        public async Task<Pelicula> AddAsync(string nombre, string genero,int duracion, string trailer_url, string sinopsis, string portada_url)
        {
            //creamos un objeto del tipo Nota con los parámetros que llegan
            Pelicula pelicula = new Pelicula()
            {
                nombre = nombre,
                genero = genero,
                duracion = duracion,
                trailer_url = trailer_url,
                sinopsis = sinopsis,
                portada_url = portada_url
            };

            

            //enviamos por POST el objeto que creamos a la URL de la API
            var response = await client.PostAsync(Url,
                new StringContent(
                    JsonConvert.SerializeObject(pelicula),
                    Encoding.UTF8, "application/json"));

            //retorna el objeto que se agregó en la API ya con su ID generado por la base de datos
            return JsonConvert.DeserializeObject<Pelicula>(
                await response.Content.ReadAsStringAsync());
        }

        public async Task<bool> RemoveAsync(string id)
        {
            var response = await client.DeleteAsync(Url + "/" + id);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateAsync(string nombre, string genero, int duracion, string trailer_url, string sinopsis, string portada_url, string id)
        {
            Pelicula pelicula = new Pelicula()
            {
                _id = id,
                nombre = nombre,
                genero = genero,
                duracion = duracion,
                trailer_url = trailer_url,
                sinopsis = sinopsis,
                portada_url = portada_url
            };
            var response = await client.PutAsync(Url + "/" + id, new StringContent(JsonConvert.SerializeObject(pelicula), Encoding.UTF8, "application/json"));
            return response.IsSuccessStatusCode;
        }

        public async Task<IEnumerable<Pelicula>> GetAllAsync()
        {
            var response = await client.GetStringAsync(Url);
            return JsonConvert.DeserializeObject<IEnumerable<Pelicula>>(response);
        }

        public async Task<Pelicula> GetById(string id)
        {
            var response = await client.GetStringAsync($"{Url}/{id}");
            return JsonConvert.DeserializeObject<Pelicula>(response);
        }


    }
}
