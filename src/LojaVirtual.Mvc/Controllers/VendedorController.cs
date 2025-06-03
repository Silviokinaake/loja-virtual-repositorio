using LojaVirtual.Mvc.Services;
using LojaVirtual.Mvc.ViewModels.Vendedores;
using Microsoft.AspNetCore.Mvc;

namespace LojaVirtual.Mvc.Controllers
{
    public class VendedorController : Controller
    {
        private readonly VendedorService _vendedorService;

        public VendedorController(VendedorService vendedorService)
        {
            _vendedorService = vendedorService;
        }

        public async Task<IActionResult> Index()
        {
            var vendedores = await _vendedorService.GetAllAsync();
            return View(vendedores);
        }

        public async Task<IActionResult> Details(int id)
        {
            var vendedor = await _vendedorService.GetByIdAsync(id);
            if (vendedor == null) return NotFound();

            return View(vendedor);
        }

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Vendedor vendedor)
        {
            if (!ModelState.IsValid) return View(vendedor);

            var sucesso = await _vendedorService.CreateAsync(vendedor);
            if (sucesso) return RedirectToAction(nameof(Index));

            ModelState.AddModelError("", "Erro ao criar vendedor.");
            return View(vendedor);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var vendedor = await _vendedorService.GetByIdAsync(id);
            if (vendedor == null) return NotFound();

            return View(vendedor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Vendedor vendedor)
        {
            if (id != vendedor.Id) return NotFound();
            if (!ModelState.IsValid) return View(vendedor);

            var sucesso = await _vendedorService.UpdateAsync(id, vendedor);
            if (sucesso) return RedirectToAction(nameof(Index));

            ModelState.AddModelError("", "Erro ao editar vendedor.");
            return View(vendedor);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var vendedor = await _vendedorService.GetByIdAsync(id);
            if (vendedor == null) return NotFound();

            return View(vendedor);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sucesso = await _vendedorService.DeleteAsync(id);
            if (!sucesso)
                return Problem("Erro ao excluir vendedor.");

            return RedirectToAction(nameof(Index));
        }
    }
}
