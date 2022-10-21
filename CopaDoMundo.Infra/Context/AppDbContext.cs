using CopaDoMundo.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CopaDoMundo.Infra.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<SelecaoEntity> Selecao { get; set; }
        public DbSet<UsuarioEntity> Usuario { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
