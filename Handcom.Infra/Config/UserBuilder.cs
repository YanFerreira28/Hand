using Handcom.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Handcom.Infra.Config
{
    public class UserBuilder : IEntityTypeConfiguration<Users>
    {
        public void Configure(EntityTypeBuilder<Users> builder)
        {
            builder.ToTable("User");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Password).HasMaxLength(100).IsRequired();
            builder.Property(c => c.Name).HasMaxLength(100).IsRequired();
            builder.Property(c => c.Email).HasMaxLength(150).IsRequired();
            builder.Property(c => c.CreatedAt).IsRequired();
        }
    }
}
