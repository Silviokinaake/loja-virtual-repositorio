using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LojaVirtual.Mvc.Data;

public class ApplicationDbContextMvc : IdentityDbContext
{
    public ApplicationDbContextMvc(DbContextOptions<ApplicationDbContextMvc> options)
        : base(options)
    {
    }
}
