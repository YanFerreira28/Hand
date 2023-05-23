using Handcom.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Handcom.Infra.Config
{
    public class ProductBuilder : IEntityTypeConfiguration<Products>
    {
        public void Configure(EntityTypeBuilder<Products> builder)
        {
            builder.ToTable("Product");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.CreatedAt).IsRequired();
            builder.Property(c => c.SupplierId).IsRequired();
            builder.Property(c => c.CategoryId).IsRequired();
            builder.Property(c => c.Description).HasMaxLength(100).IsRequired();
            builder.Property(c => c.Name).HasMaxLength(100).IsRequired();
        }
    }
}
