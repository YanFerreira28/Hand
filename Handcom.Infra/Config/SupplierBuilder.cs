using Handcom.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Handcom.Infra.Config
{
    public class SupplierBuilder : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.ToTable("Supplier");
            builder.HasKey(x => x.Id);
            builder.Property(c=> c.Name).HasMaxLength(100).IsRequired();
        }
    }
}
