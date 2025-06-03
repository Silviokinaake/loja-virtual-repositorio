using LojaVirtual.Mvc.ViewModels.Vendedores;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LojaVirtual.Core.Abstractions.Services
{
    public interface IVendedorService
    {
        Task<List<Vendedor>> GetAllAsync();
        Task<Vendedor> GetByIdAsync(int id);
        Task<bool> CreateAsync(Vendedor vendedor);
        Task<bool> UpdateAsync(int id, Vendedor vendedor);
        Task<bool> DeleteAsync(int id);
    }
}
