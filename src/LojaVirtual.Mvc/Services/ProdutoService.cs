using LojaVirtual.Mvc.ViewModels.Produtos;

namespace LojaVirtual.Mvc.Services
{
    public class ProdutoService: IProdutoService
    {
        private readonly HttpClient _httpClient;

        public ProdutoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<ProdutoViewModel>> ObterTodosAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<ProdutoViewModel>>("api/produtos") ?? new List<ProdutoViewModel>();
        }

        public async Task<ProdutoViewModel?> ObterPorIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<ProdutoViewModel>($"api/produtos/{id}");
        }

        public async Task<bool> CriarAsync(ProdutoViewModel produto)
        {
            var resposta = await _httpClient.PostAsJsonAsync("api/produtos", produto);
            return resposta.IsSuccessStatusCode;
        }

        public async Task<bool> AtualizarAsync(ProdutoViewModel produto)
        {
            var resposta = await _httpClient.PutAsJsonAsync($"api/produtos/{produto.Id}", produto);
            return resposta.IsSuccessStatusCode;
        }

        public async Task<bool> ExcluirAsync(int id)
        {
            var resposta = await _httpClient.DeleteAsync($"api/produtos/{id}");
            return resposta.IsSuccessStatusCode;
        }
    }
}
