using LojaVirtual.Api.Data.LojaVirtual.Api.Data;
using Microsoft.EntityFrameworkCore;

namespace LojaVirtual.Api.Configurations
{
    public static class DatabaseSelectorExtension
    {
        public static void AddDatabaseSelector(this WebApplicationBuilder builder)
        {
            if (builder.Environment.IsDevelopment())
            {
                builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnectionLite")));

              //  builder.Services.AddDbContext<ApplicationDbContextMvc>(options =>
              //options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnectionLite")));
            }
            else
            {
                var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
                
                //builder.Services.AddDbContext<ApplicationDbContextMvc>(options =>
                //    options.UseSqlite(connectionString));
                //builder.Services.AddDatabaseDeveloperPageExceptionFilter();

                connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
                builder.Services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlite(connectionString));

                //builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            }

        }
    }
}
