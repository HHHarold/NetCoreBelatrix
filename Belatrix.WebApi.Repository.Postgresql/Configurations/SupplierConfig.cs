using Belatrix.WebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Belatrix.WebApi.Repository.Postgresql.Configurations
{
    internal class SupplierConfig : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.ToTable("supplier");

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .UseNpgsqlIdentityColumn();

            builder.Property(e => e.CompanyName)
                .HasColumnName("company_name")
                .HasMaxLength(40)
                .IsRequired();

            builder.HasIndex(e => e.CompanyName)
                .HasName("supplier_company_name_idx");

            builder.Property(e => e.ContactName)
                .HasColumnName("contact_name")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(e => e.ContactTitle)
                .HasColumnName("contact_title")
                .HasMaxLength(40)
                .IsRequired();

            builder.Property(p => p.City)
                .HasColumnName("city")
                .HasMaxLength(40)
                .IsRequired();

            builder.Property(p => p.Country)
                .HasColumnName("country")
                .HasMaxLength(40)
                .IsRequired();

            builder.HasIndex(e => e.Country)
                .HasName("supplier_country_idx");

            builder.Property(p => p.Phone)
                .HasColumnName("phone")
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(p => p.Fax)
                .HasColumnName("fax")
                .HasMaxLength(30)
                .IsRequired();
        }
    }
}
