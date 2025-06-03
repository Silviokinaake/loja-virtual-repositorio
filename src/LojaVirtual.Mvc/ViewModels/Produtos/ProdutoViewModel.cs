using LojaVirtual.Mvc.ViewModels.Categorias;
using LojaVirtual.Mvc.ViewModels.Vendedores;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace LojaVirtual.Mvc.ViewModels.Produtos
{
    public class ProdutoViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "O campo {0} deve ter entre {2} e {1} caracteres.")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "O campo {0} deve ter entre {2} e {1} caracteres.")]
        public string? Descricao { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        [Range(1, int.MaxValue, ErrorMessage = "O preço deve ser maior que zero")]
        [Precision(18, 2)]
        public decimal? Preco { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        [Display(Name = "Quantidade")]
        public int QuantidadeEstoque { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "O campo {0} deve ter entre {2} e {1} caracteres.")]
        public CategoriaViewModel? Categoria { get; set; }

        [Display(Name = "Imagem")]
        public string? ImagemUrl { get; set; }

        public int VendedorId { get; set; }
        public Vendedor? Vendedor { get; set; }
    }
}
