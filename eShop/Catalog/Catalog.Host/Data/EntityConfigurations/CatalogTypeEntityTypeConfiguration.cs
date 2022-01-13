using Catalog.Host.Data.Entities;

namespace Catalog.Host.Data.EntityConfigurations;

public class CatalogTypeEntityTypeConfiguration
    : IEntityTypeConfiguration<CatalogType>
{
    public void Configure(EntityTypeBuilder<CatalogType> builder)
    {
        builder.ToTable("CatalogType");

        builder.HasKey(ct => ct.Id);

        builder.Property(ct => ct.Id)
            .UseHiLo("catalog_type_hilo")
            .IsRequired();

        builder.Property(ct => ct.Type)
            .IsRequired()
            .HasMaxLength(100);
    }
}
