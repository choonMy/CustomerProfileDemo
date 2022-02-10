using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class CustomerProfileConfiguration : IEntityTypeConfiguration<CustomerProfile>
    {
        public void Configure(EntityTypeBuilder<CustomerProfile> builder)
        {
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Surname).IsRequired().HasMaxLength(50);
            builder.Property(p => p.Email).IsRequired();
            builder.Property(p => p.Mobile).IsRequired();
            builder.Property(p => p.Occupation).IsRequired();
        }
    }
}