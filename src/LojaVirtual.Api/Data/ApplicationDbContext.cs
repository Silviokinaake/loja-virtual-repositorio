namespace LojaVirtual.Api.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using VirtualStore.Domain.Categorias;
    using VirtualStore.Domain.Entities;
    using VirtualStore.Domain.Produtos;

    namespace LojaVirtual.Api.Data
    {
        public class ApplicationDbContext : IdentityDbContext
        {
            public ApplicationDbContext(DbContextOptions options) : base(options) { }

            public DbSet<Vendedor> Vendedores { get; set; }
            public DbSet<Categoria> Categorias { get; set; }
            public DbSet<Produto> Produtos { get; set; }

            protected override void OnModelCreating(ModelBuilder builder)
            {
                base.OnModelCreating(builder);

                builder.Entity<Vendedor>().HasKey(v => v.Id);
                builder.Entity<Categoria>().HasKey(c => c.Id);
                builder.Entity<Produto>().HasKey(p => p.Id);
            }
        }
    }
}
