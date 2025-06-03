using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using VirtualStore.Domain.Produtos;

namespace VirtualStore.Domain.Entities
{
    public class Vendedor : IdentityUser<int>
    {
        [Required]
        [StringLength(100)]
        public string? Nome { get; set; }

        public ICollection<Produto> Produtos { get; set; } = new List<Produto>();
    }
}
