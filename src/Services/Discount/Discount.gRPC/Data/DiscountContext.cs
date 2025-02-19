using Discount.gRPC.Models;
using Microsoft.EntityFrameworkCore;

namespace Discount.gRPC.Data;

public class DiscountContext : DbContext
{
    public DbSet<Coupon> Coupons { get; set; } = default!;

    public DiscountContext(DbContextOptions<DiscountContext> options) 
        : base(options)
    {          
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Coupon>().HasData(
            new Coupon { Id = 1, Name = "c101", ProductName = "IPhone X", Description = "IPhone Discount", Amount = 150 },
            new Coupon { Id = 2, Name = "c202", ProductName = "Samsung 10", Description = "Samsung Discount", Amount = 100 }
            );

        base.OnModelCreating(modelBuilder);
    }
}
