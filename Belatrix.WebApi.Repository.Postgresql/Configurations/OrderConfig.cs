using Belatrix.WebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Belatrix.WebApi.Repository.Postgresql.Configurations
{
    internal class OrderConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("order");

            builder.Property(p => p.Id)
                .HasColumnName("id")
                .UseNpgsqlIdentityColumn();

            builder.HasIndex(e => e.Id)
               .HasName("order_id_idx");


            builder.Property(p => p.OrderDate)
                .HasColumnName("order_date")
                .IsRequired();

            builder.HasIndex(e => e.OrderDate)
                .HasName("order_order_date_idx");

            builder.Property(p => p.OrderNumber)
                .HasColumnName("order_number")
                .HasMaxLength(10)
                .IsRequired();

            builder.Property(p => p.CustomerId)
                .HasColumnName("customer_id")
                .IsRequired();

            builder.HasOne(p => p.CustomerNavigation)
                .WithMany(p => p.Orders)
                .HasForeignKey(p => p.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("order_customer_id_fkey");

            builder.Property(p => p.TotalAmount)
                .HasColumnName("total_amount")
                .HasColumnType("decimal(12,2)")
                .IsRequired();
        }
    }
}
