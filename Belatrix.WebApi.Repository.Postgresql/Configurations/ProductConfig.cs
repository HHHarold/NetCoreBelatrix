using Belatrix.WebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Belatrix.WebApi.Repository.Postgresql.Configurations
{
    internal class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("product");

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .UseNpgsqlIdentityColumn();

            builder.Property(e => e.ProductName)
                .HasColumnName("product_name")
                .HasMaxLength(50)
                .IsRequired();

            builder.HasIndex(e => e.ProductName)
                .HasName("product_product_name_idx");

            builder.Property(e => e.SupplierId)
                .HasColumnName("supplier_id")
                .IsRequired();

            builder.HasIndex(e => e.SupplierId)
                .HasName("product_supplier_id_idx");

            builder.HasOne(e => e.SupplierNavigation)
                .WithMany(e => e.Products)
                .HasForeignKey(p => p.SupplierId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("product_supplier_id_fkey");

            builder.Property(e => e.UnitPrice)
                .HasColumnName("unit_price")
                .HasColumnType("decimal(12,2)")
                .IsRequired();

            builder.Property(e => e.Package)
                .HasColumnName("package")
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(e => e.IsDiscontinued)
                .HasColumnName("is_idscontinued")
                .IsRequired();
        }
    }
}
