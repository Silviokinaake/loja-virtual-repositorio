using LojaVirtual.Mvc.Services;
using LojaVirtual.Mvc.ViewModels.Categorias;
using LojaVirtual.Mvc.ViewModels.Produtos;
using VirtualStore.Domain.Categorias;

public class CategoriaService : ICategoriaService
{
    private readonly HttpClient _httpClient;
    private readonly string _baseUrl;

    public CategoriaService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _baseUrl = configuration["ApiSettings:BaseUrl"];
    }

    public async Task<List<CategoriaViewModel>> ObterTodosAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<CategoriaViewModel>>($"{_baseUrl}/api/categorias");
    }

    public async Task<CategoriaViewModel?> ObterPorIdAsync(int id)
    {
        return await _httpClient.GetFromJsonAsync<CategoriaViewModel>($"api/categorias/{id}");
    }

    public async Task<bool> CriarAsync(CategoriaViewModel categoria)
    {
        var resposta = await _httpClient.PostAsJsonAsync("api/categorias", categoria);
        return resposta.IsSuccessStatusCode;
    }

    public async Task<bool> AtualizarAsync(int id, CategoriaViewModel categoria)
    {
        var resposta = await _httpClient.PutAsJsonAsync($"api/categorias/{id}", categoria);
        return resposta.IsSuccessStatusCode;
    }

    public async Task<bool> ExcluirAsync(int id)
    {
        var resposta = await _httpClient.DeleteAsync($"api/categorias/{id}");
        return resposta.IsSuccessStatusCode;
    }
}
