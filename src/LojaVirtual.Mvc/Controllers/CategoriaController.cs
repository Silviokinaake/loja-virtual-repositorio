using LojaVirtual.Mvc.Services;
using LojaVirtual.Mvc.ViewModels.Categorias;
using Microsoft.AspNetCore.Mvc;

namespace LojaVirtual.Mvc.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly ICategoriaService _categoriaService;

        public CategoriaController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        public async Task<IActionResult> Index()
        {
            var categorias = await _categoriaService.ObterTodosAsync();
            return View(categorias);
        }

        [Route("detalhes/{id:int}")]
        public async Task<IActionResult> Details(int id)
        {
            var categoria = await _categoriaService.ObterPorIdAsync(id);
            if (categoria == null)
                return NotFound();

            return View(categoria);
        }

        [Route("novo")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("novo")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id, Nome")]CategoriaViewModel categoria)
        {
            if (ModelState.IsValid)
                return View(categoria);

            var sucesso = await _categoriaService.CriarAsync(categoria);

            if (sucesso)
                return RedirectToAction(nameof(Index));

            ModelState.AddModelError("", "Erro ao criar categoria.");
            return View(categoria);
        }

        [Route("editar/{id:int}")]
        public async Task<IActionResult> Edit(int id)
        {
            var categoria = await _categoriaService.ObterPorIdAsync(id);
            if (categoria == null)
                return NotFound();

            return View(categoria);
        }

        [HttpPost("editar/{id:int}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CategoriaViewModel categoria)
        {
            if (id != categoria.Id)
                return NotFound();

            if (!ModelState.IsValid)
                return View(categoria);

            var sucesso = await _categoriaService.AtualizarAsync(id, categoria);

            if (sucesso)
            {
                TempData["Sucesso"] = "Categoria editada com sucesso!";
                return RedirectToAction(nameof(Index));
            }

            ModelState.AddModelError("", "Erro ao editar categoria.");
            return View(categoria);
        }

        [Route("excluir/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var categoria = await _categoriaService.ObterPorIdAsync(id);
            if (categoria == null)
                return NotFound();

            return View(categoria);
        }

        [HttpPost("excluir/{id:int}"), ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sucesso = await _categoriaService.ExcluirAsync(id);

            if (!sucesso)
                return Problem("Erro ao excluir categoria.");

            return RedirectToAction(nameof(Index));
        }
    }
}
