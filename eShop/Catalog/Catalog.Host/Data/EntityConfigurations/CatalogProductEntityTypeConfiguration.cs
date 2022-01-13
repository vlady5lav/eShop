using Catalog.Host.Data.Entities;

namespace Catalog.Host.Data.EntityConfigurations;

public class CatalogProductEntityTypeConfiguration
    : IEntityTypeConfiguration<CatalogProduct>
{
    public void Configure(EntityTypeBuilder<CatalogProduct> builder)
    {
        builder.ToTable("CatalogProduct");

        builder.Property(cp => cp.Id)
            .UseHiLo("catalog_product_hilo")
            .IsRequired();

        builder.Property(cp => cp.Name)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(cp => cp.Description)
            .IsRequired(false);

        builder.Property(cp => cp.Price)
            .IsRequired();

        builder.Property(cp => cp.PictureFileName)
            .IsRequired(false);

        builder.HasOne(cp => cp.CatalogBrand)
            .WithMany()
            .HasForeignKey(cp => cp.CatalogBrandId);

        builder.HasOne(cp => cp.CatalogType)
            .WithMany()
            .HasForeignKey(cp => cp.CatalogTypeId);
    }
}
