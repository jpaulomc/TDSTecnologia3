using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TDSTecnologia.Site.Core.Entities;

namespace TDSTecnologia.Site.Infrastructure.Map
{
    class PermissaoMapConfiguration : IEntityTypeConfiguration<Permissao>
    {
        public void Configure(EntityTypeBuilder<Permissao> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(n => n.Descricao).HasColumnName("descricao").IsRequired().HasMaxLength(400);
            builder.ToTable("tb03_permissao");
        }
    }
}
