
using Handcom.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Handcom.Infra.Config
{
    public class CategoryBuilder : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Category");
            builder.HasKey(c=> c.Id);
            builder.Property(c => c.Name).HasMaxLength(100).IsRequired();
        }
    }
}
