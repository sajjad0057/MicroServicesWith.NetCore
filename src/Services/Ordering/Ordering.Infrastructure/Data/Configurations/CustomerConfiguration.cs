using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ordering.Domain.Entities;
using Ordering.Domain.ValueObjects;

namespace Ordering.Infrastructure.Data.Configurations;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasConversion(
            CustomerId => CustomerId.Value,
            dbId => CustomerId.Of(dbId));

        builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
        builder.Property(x => x.Email).IsRequired().HasMaxLength(255);
        builder.HasIndex(x => x.Email).IsUnique();
    }
}
