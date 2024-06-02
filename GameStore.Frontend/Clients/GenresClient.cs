using GameStore.Frontend.Models;
using System.Net.Http;
using System.Net.Http.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace GameStore.Frontend.Clients
{
    public class GenresClient
    {
        private readonly HttpClient _httpClient;

        public GenresClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Genre>> GetGenresAsync()
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<IEnumerable<Genre>>("genres");
                return response ?? new List<Genre>();
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error fetching genres: {ex.Message}");
                throw;
            }
        }

        public async Task AddGenreAsync(Genre genre)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("genres", genre);
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error adding genre: {ex.Message}");
                throw;
            }
        }

        public async Task DeleteGenreAsync(int genreId)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"genres/{genreId}");
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error deleting genre: {ex.Message}");
                throw;
            }
        }
    }
}
