using Handcom.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handcom.Infra.Config
{
    public class SessionBuilder : IEntityTypeConfiguration<Session>
    {
        public void Configure(EntityTypeBuilder<Session> builder)
        {
            builder.ToTable("Session");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.IsActive).IsRequired();
            builder.Property(c => c.Name).HasMaxLength(100).IsRequired();
            builder.Property(c => c.UserId).IsRequired();
            builder.HasOne(c => c.User).WithOne(c=> c.Session).HasForeignKey<Session>(c=> c.UserId);
        }
    }
}
