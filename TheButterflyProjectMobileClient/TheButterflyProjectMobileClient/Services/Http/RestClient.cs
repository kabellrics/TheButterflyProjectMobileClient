using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using TheButterflyProjectMobileClient.Models.Interface;

namespace TheButterflyProjectMobileClient.Services.Http
{
    public class RestClient<T> where T : class, OfflineClientEntity
    {
        private readonly HttpClient _http;
        private readonly string _endpoint;
        public RestClient(HttpClient http, string endpoint)
        {
            _http = http;
            _endpoint = endpoint.TrimEnd('/');
        }
        public async Task<List<T>> GetAllAsync()
        {
            var allItems = new List<T>();
            string baseEndpoint = _endpoint.TrimEnd('/');
            string? next = baseEndpoint;

            while (!string.IsNullOrWhiteSpace(next))
            {
                var page = await _http.GetFromJsonAsync<PagedResult<T>>(next);
                if (page == null)
                    break;
                if (page.Items?.Count > 0)
                    allItems.AddRange(page.Items);
                if (string.IsNullOrWhiteSpace(page.NextLink))
                {
                    next = null;
                }
                else if (Uri.IsWellFormedUriString(page.NextLink, UriKind.Absolute))
                {
                    // nextLink absolu → on l’utilise tel quel
                    next = page.NextLink;
                }
                else
                {
                    // nextLink relatif → on le rattache à l’endpoint
                    next = $"{baseEndpoint}?{page.NextLink}";
                }
            }
            return allItems;
        }

        public async Task<T?> GetByIdAsync(string id)
        {
            return await _http.GetFromJsonAsync<T>($"{_endpoint}/{id}");
        }
        public async Task<T> CreateAsync(T entity)
        {
            var response = await _http.PostAsJsonAsync(_endpoint, entity);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<T>()
                   ?? throw new InvalidOperationException("Empty response");
        }
        public async Task UpdateAsync(T entity)
        {
            var response = await _http.PutAsJsonAsync(
                $"{_endpoint}/{entity.Id}", entity);

            response.EnsureSuccessStatusCode();
        }
        public async Task DeleteAsync(string id)
        {
            var response = await _http.DeleteAsync($"{_endpoint}/{id}");
            response.EnsureSuccessStatusCode();
        }
        public async Task PushAsync(T entity)
        {
            if (entity.Deleted)
            {
                await DeleteAsync(entity.Id);
            }
            else
            {
                await UpdateAsync(entity);
            }
        }
    }
}
