using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VirtualStore.Domain.Entities;
using LojaVirtual.Api.Data.LojaVirtual.Api.Data;

namespace LojaVirtual.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VendedoresController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public VendedoresController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vendedor>>> GetAll()
        {
            return await _context.Vendedores.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Vendedor>> GetById(int id)
        {
            var vendedor = await _context.Vendedores.FindAsync(id);
            if (vendedor == null) return NotFound();
            return vendedor;
        }

        [HttpPost]
        public async Task<ActionResult<Vendedor>> Create(Vendedor vendedor)
        {
            _context.Vendedores.Add(vendedor);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = vendedor.Id }, vendedor);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Vendedor vendedor)
        {
            if (id != vendedor.Id) return BadRequest();

            _context.Entry(vendedor).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var vendedor = await _context.Vendedores.FindAsync(id);
            if (vendedor == null) return NotFound();

            _context.Vendedores.Remove(vendedor);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
