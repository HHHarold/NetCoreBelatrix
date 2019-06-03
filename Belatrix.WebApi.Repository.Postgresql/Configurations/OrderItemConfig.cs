using Belatrix.WebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Belatrix.WebApi.Repository.Postgresql.Configurations
{
    internal class OrderItemConfig : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.ToTable("order_item");

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .UseNpgsqlIdentityColumn();

            builder.HasIndex(e => e.Id)
                .HasName("order_item_id_idx");

            builder.Property(e => e.OrderId)
                .IsRequired();

            builder.HasOne(e => e.OrderNavigation)
                .WithMany(e => e.OrderItems)
                .HasForeignKey(e => e.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("order_item_order_id_fkey");

            builder.Property(e => e.ProductId)
                .IsRequired();

            builder.HasOne(e => e.ProductNavigation)
                .WithMany(e => e.OrderItems)
                .HasForeignKey(e => e.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("order_item_product_id_fkey");

            builder.HasIndex(e => e.ProductId)
                .HasName("order_item_product_id_idx");

            builder.Property(e => e.UnitPrice)
                .HasColumnName("unit_price")
                .HasColumnType("decimal(12,2)")
                .IsRequired();

            builder.Property(e => e.Quantity)
                .HasColumnName("quantity")
                .IsRequired();
        }
    }
}
