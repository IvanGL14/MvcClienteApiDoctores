using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using NugetDoctores;
using System.Net.Http;

namespace MvcClienteApiDoctores.Services
{
    public class ServiceApiDoctores
    {
        private string UrlApi;
        private MediaTypeWithQualityHeaderValue Header;

        public ServiceApiDoctores(string url)
        {
            this.UrlApi = url;
            this.Header = new MediaTypeWithQualityHeaderValue("application/json");
        }

        private async Task<T> CallApiAsyn<T>(string request)
        {
            using(HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(this.UrlApi);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.Header);
                HttpResponseMessage response = await client.GetAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    T data = await response.Content.ReadAsAsync<T>();
                    return data;
                }
                else
                {
                    return default(T);
                }
            }
        }

        public async Task<List<Doctor>> GetDoctoresAsync()
        {
            string request = "api/Doctores";
            List<Doctor> doctores = await CallApiAsyn<List<Doctor>>(request);
            return doctores;
        }

        public async Task<List<string>> GetEspecialidadesAsync()
        {
            string request = "api/Doctores/Especialidades";
            List<string> especialidades = await CallApiAsyn<List<string>>(request);
            return especialidades;
        }

        public async Task<List<Doctor>> GetDoctoresEspecialidadAsync(string especialidad)
        {
            string request = "api/Doctores/DoctoresEspecialidad/" + especialidad;
            List<Doctor> doctores = await CallApiAsyn<List<Doctor>>(request);
            return doctores;
        }

    }
}
