using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TDSTecnologia.Site.Core.Entities;
using TDSTecnologia.Site.Infrastructure.Map;

namespace TDSTecnologia.Site.Infrastructure.Data
{
    public class AppContexto : IdentityDbContext<Usuario, Permissao, string>
    {
        public AppContexto(DbContextOptions<AppContexto> opcoes) : base(opcoes)
        {
        }

        public DbSet<Curso> CursoDao { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Permissao> Permissoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.HasDefaultSchema("tds");
            modelBuilder.ApplyConfiguration(new CursoMapConfiguration());
            modelBuilder.ApplyConfiguration(new UsuarioMapConfiguration());
            modelBuilder.ApplyConfiguration(new PermissaoMapConfiguration());
        }

    }
}
