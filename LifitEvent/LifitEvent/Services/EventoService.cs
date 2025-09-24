using LifitEvent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace LifitEvent.Services
{
    public class EventoService 
    {
        private readonly HttpClient _httpClient;

        public EventoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Evento>> GetEventosAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Evento>>("api/eventos");
        }

        public async Task<Evento> GetEventoByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Evento>($"api/eventos/{id}");
        }

        public async Task<bool> AddEventoAsync(Evento evento)
        {
            var response = await _httpClient.PostAsJsonAsync("api/eventos", evento);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateEventoAsync(Evento evento)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/eventos/{evento.Id}", evento);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteEventoAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/eventos/{id}");
            return response.IsSuccessStatusCode;
        }
    }


}
