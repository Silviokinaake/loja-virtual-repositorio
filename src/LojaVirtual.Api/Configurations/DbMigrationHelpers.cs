using LojaVirtual.Api.Data.LojaVirtual.Api.Data;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using VirtualStore.Domain.Produtos;

namespace LojaVirtual.Api.Configurations
{

    public static class DbMigrationHelperExtencion
    {
        public static void UseDbMigrationHelper(this WebApplication app)
        {
            DbMigrationHelpers.EnsureSeedData(app).Wait();
        }
            
    }

    public static class DbMigrationHelpers
    {
        public static async Task EnsureSeedData(WebApplication serviceScope)
        {
            var service = serviceScope.Services.CreateScope().ServiceProvider;
            await EnsureSeedData(service);
        }

        public static async Task EnsureSeedData(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope();
            var env = scope.ServiceProvider.GetRequiredService<IHostEnvironment>();

            //var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContextMvc>();
            var contextId = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            
            if (env.IsDevelopment() || env.IsEnvironment("Docker") || env.IsStaging())
            {
                //await context.Database.MigrateAsync();
                await contextId.Database.MigrateAsync();
            }
        }

        //public static async Task EnsureSeedData(ApplicationDbContext context)
        //{

        //}
    }
}
