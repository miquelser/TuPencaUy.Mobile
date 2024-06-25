using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TuPencaUy.Mobile.Models;

namespace TuPencaUy.Mobile.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<List<Campeonato>> GetCampeonatosAsync()
        {
            string url = "URL_DE_LA_API_CAMPEONATOS";
            var response = await _httpClient.GetStringAsync(url);
            return JsonConvert.DeserializeObject<List<Campeonato>>(response);
        }

        public async Task<List<Partido>> GetPartidosAsync(int campeonatoId)
        {
            string url = $"URL_DE_LA_API_PARTIDOS?campeonatoId={campeonatoId}";
            var response = await _httpClient.GetStringAsync(url);
            return JsonConvert.DeserializeObject<List<Partido>>(response);
        }

        public async Task<Partido> GetPartidoDetalleAsync(int partidoId)
        {
            string url = $"URL_DE_LA_API_PARTIDO_DETALLE?partidoId={partidoId}";
            var response = await _httpClient.GetStringAsync(url);
            return JsonConvert.DeserializeObject<Partido>(response);
        }
    }
}