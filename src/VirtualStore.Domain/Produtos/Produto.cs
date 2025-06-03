using VirtualStore.Domain.Categorias;
using VirtualStore.Domain.Entities;

namespace VirtualStore.Domain.Produtos
{
    public class Produto
    {
        public int Id { get; set; }

        public string? Nome { get; set; }

        public string? Descricao { get; set; }

        public decimal Preco { get; set; }

        public int QuantidadeEstoque { get; set; }

        public string? ImagemUrl { get; set; }

        public int CategoriaId { get; set; }
        public Categoria? Categoria { get; set; }

        public int VendedorId { get; set; }
        public Vendedor? Vendedor { get; set; }
    }
}
