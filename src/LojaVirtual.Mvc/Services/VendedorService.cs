using LojaVirtual.Core.Abstractions.Services;
using LojaVirtual.Mvc.ViewModels.Vendedores;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LojaVirtual.Mvc.Services
{
    public class VendedorService: IVendedorService
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "https://localhost:5001/api/vendedores";

        public VendedorService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Vendedor>> GetAllAsync()
        {
            var response = await _httpClient.GetAsync(BaseUrl);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<Vendedor>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<Vendedor> GetByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"{BaseUrl}/{id}");
            if (!response.IsSuccessStatusCode) return null;

            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Vendedor>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<bool> CreateAsync(Vendedor vendedor)
        {
            var json = JsonSerializer.Serialize(vendedor);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(BaseUrl, content);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateAsync(int id, Vendedor vendedor)
        {
            var json = JsonSerializer.Serialize(vendedor);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync($"{BaseUrl}/{id}", content);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{BaseUrl}/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}

