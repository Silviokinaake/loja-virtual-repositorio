using LojaVirtual.Mvc.ViewModels.Produtos;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace LojaVirtual.Mvc.ViewModels.Vendedores
{
    public class Vendedor : IdentityUser<int>
    {
        [Required]
        [StringLength(100)]
        public string? Nome { get; set; }

        public ICollection<ProdutoViewModel> Produtos { get; set; } = new List<ProdutoViewModel>();
    }
}
