using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TDSTecnologia.Site.Core.Entities;

namespace TDSTecnologia.Site.Infrastructure.Map
{
    public class UsuarioMapConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.Property(u => u.Nome).IsRequired().HasMaxLength(100).HasColumnName("nome");
            builder.Property(u => u.CPF).IsRequired().HasColumnName("cpf");
            builder.HasIndex(u => u.CPF).IsUnique();
            builder.Property(u => u.Telefone).IsRequired().HasMaxLength(30).HasColumnName("telefone");

            builder.Ignore(u => u.EmailConfirmed);
            builder.Ignore(u => u.AccessFailedCount);
            builder.Ignore(u => u.LockoutEnabled);
            builder.Ignore(u => u.LockoutEnd);
            builder.Ignore(u => u.PhoneNumber);
            builder.Ignore(u => u.PhoneNumberConfirmed);
            builder.Ignore(u => u.TwoFactorEnabled);

            builder.ToTable("tb02_usuario");
        }
    }
}
