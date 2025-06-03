using LojaVirtual.Mvc.ViewModels.Categorias;

namespace LojaVirtual.Mvc.Services
{
    public interface ICategoriaService
    {
        Task<List<CategoriaViewModel>> ObterTodosAsync();
        Task<CategoriaViewModel?> ObterPorIdAsync(int id);
        Task<bool> CriarAsync(CategoriaViewModel categoria);
        Task<bool> AtualizarAsync(int id, CategoriaViewModel categoria);
        Task<bool> ExcluirAsync(int id);
    }
}