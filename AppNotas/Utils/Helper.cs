using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
