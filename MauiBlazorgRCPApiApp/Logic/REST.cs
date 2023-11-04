using DataView2.Core.Models;
using MauiBlazorgRCPApiApp.Data;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Json;
using System.Net.NetworkInformation;
using System.Text;

namespace MauiBlazorgRCPApiApp.Logic
{

    public class REST
    {
        //static readonly string baseUrl = "https://localhost:44344/";
        //static private readonly HttpClient httpClient = new(); static readonly 
        private const string baseUrl = "https://localhost:44344/";
        private readonly HttpClient _httpClient;

        public REST()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(baseUrl)
            };
        }
        public async Task<List<PersonaDb>> LoadPersonaDb()
        {
            string apiUrl = $"{baseUrl}PersonaDb";

            if (!IsNetworkAvailable())
            {
                throw new InvalidOperationException("No hay conexión de red disponible.");
            }

            try
            {
                var response = await _httpClient.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    var personas = await response.Content.ReadFromJsonAsync<PersonaDb[]>();
                    return personas.ToList();
                }
                else
                {
                    throw new HttpRequestException($"Error en la solicitud: {response.StatusCode}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new ApplicationException($"Error al obtener datos de la API: {ex.Message}", ex);
            }
        }

        internal static bool IsNetworkAvailable()
        {
            return NetworkInterface.GetIsNetworkAvailable();
        }

        public async Task<string> AddPersonaDb(PersonaDb persona)
        {
            try
            {
                string apiUrl = $"{baseUrl}PersonaDb";

                if (!IsNetworkAvailable())
                {
                    throw new Exception("No hay conexión de red disponible.");

                }

                // Configura un tiempo de espera de 10 segundos para la solicitud HTTP
                //_httpClient.Timeout = TimeSpan.FromSeconds(10);

                // Serializar el objeto persona a formato JSON
                var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(persona);
                var jsonContent = new StringContent(jsonString, Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync(apiUrl, jsonContent);
                var responseBody = await response.Content.ReadAsStringAsync();
                var responseObject = JsonConvert.DeserializeObject<PersonaDb>(responseBody);
                if (response.IsSuccessStatusCode)
                {
                    return responseObject.idPersona.ToString(); //response.
                    // Si quieres, puedes procesar la respuesta aquí o simplemente retornar true para indicar éxito
                    // return true;
                }
                else
                {
                    throw new Exception($"Error en la API: {response.StatusCode}");
                    // return false;
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error en la solicitud: {ex.Message}");
                //return false;
            }
        }
        public async Task<bool> UpdPersonaDb(PersonaDb persona)
        {
            try
            {
                string apiUrl = $"{baseUrl}PersonaDb";

                if (!IsNetworkAvailable())
                {
                    throw new Exception("No hay conexión de red disponible.");

                }

                // Configura un tiempo de espera de 10 segundos para la solicitud HTTP
                //_httpClient.Timeout = TimeSpan.FromSeconds(10);

                // Serializar el objeto persona a formato JSON
                var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(persona);
                var jsonContent = new StringContent(jsonString, Encoding.UTF8, "application/json");
                var response = await _httpClient.PutAsync($"{apiUrl}/{persona.idPersona}", jsonContent);
                var responseBody = await response.Content.ReadAsStringAsync();
                var responseObject = JsonConvert.DeserializeObject<PersonaDb>(responseBody);
                if (response.IsSuccessStatusCode)
                {
                    
                     return true;
                }
                else
                {                   
                     return false;
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error en la solicitud: {ex.Message}");                
            }
        }
        public async Task<bool> DelPersonaDb(int idPersona)
        {
            try
            {
                string apiUrl = $"{baseUrl}PersonaDb";
                if (!IsNetworkAvailable())
                {
                    throw new Exception("No hay conexión de red disponible.");

                }

                var response = await _httpClient.DeleteAsync($"{apiUrl}/{idPersona.ToString()}");
                var responseBody = await response.Content.ReadAsStringAsync();
                var responseObject = JsonConvert.DeserializeObject<string>(responseBody);
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error en la solicitud: {ex.Message}");
                //return false;
            }
        }

    }
}
