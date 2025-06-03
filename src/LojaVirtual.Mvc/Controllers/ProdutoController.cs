using LojaVirtual.Mvc.ViewModels.Produtos;
using Microsoft.AspNetCore.Mvc;
using LojaVirtual.Mvc.Services;

namespace LojaVirtual.Mvc.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IProdutoService _produtoService;

        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService
                ?? throw new ArgumentNullException(nameof(produtoService));
        }

        public async Task<IActionResult> Index()
        {
            var produtos = await _produtoService.ObterTodosAsync();
            return View(produtos);
        }

        public async Task<IActionResult> Details(int id)
        {
            var produto = await _produtoService.ObterPorIdAsync(id);
            if (produto == null)
                return NotFound();

            return View(produto);
        }

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProdutoViewModel produto)
        {
            if (!ModelState.IsValid)
                return View(produto);

            var sucesso = await _produtoService.CriarAsync(produto);
            if (!sucesso)
                ModelState.AddModelError("", "Não foi possível criar o produto.");

            TempData["Sucesso"] = "Produto criado com sucesso!";
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var produto = await _produtoService.ObterPorIdAsync(id);
            if (produto == null)
                return NotFound();
            return View(produto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProdutoViewModel produto)
        {
            if (id != produto.Id)
                return BadRequest();

            if (!ModelState.IsValid)
                return View(produto);

            var sucesso = await _produtoService.AtualizarAsync(produto);
            if (!sucesso)
                ModelState.AddModelError("", "Não foi possível atualizar o produto.");

            TempData["Sucesso"] = "Produto atualizado com sucesso!";
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var produto = await _produtoService.ObterPorIdAsync(id);
            if (produto == null)
                return NotFound();
            return View(produto);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sucesso = await _produtoService.ExcluirAsync(id);
            if (!sucesso)
                TempData["Erro"] = "Erro ao excluir produto.";
            else
                TempData["Sucesso"] = "Produto excluído com sucesso!";

            return RedirectToAction(nameof(Index));
        }
    }
}
