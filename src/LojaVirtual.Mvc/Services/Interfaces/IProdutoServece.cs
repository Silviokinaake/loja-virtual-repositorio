using LojaVirtual.Mvc.ViewModels.Produtos;

namespace LojaVirtual.Mvc.Services
{
    public interface IProdutoService
    {
        Task<IEnumerable<ProdutoViewModel>> ObterTodosAsync();
        Task<ProdutoViewModel?> ObterPorIdAsync(int id);
        Task<bool> CriarAsync(ProdutoViewModel produto);
        Task<bool> AtualizarAsync(ProdutoViewModel produto);
        Task<bool> ExcluirAsync(int id);
    }
}
