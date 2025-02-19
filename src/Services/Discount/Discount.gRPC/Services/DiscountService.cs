using Discount.gRPC.Data;
using Discount.gRPC.Models;
using Discount.gRPC.Protos;
using Grpc.Core;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Discount.gRPC.Services;

public class DiscountService(DiscountContext dbContext, ILogger<DiscountService> logger)
    : DiscountProtoService.DiscountProtoServiceBase
{
    public override async Task<CouponModel> GetDiscount(GetDiscountRequest request, 
        ServerCallContext context)
    {
        //// TODO : GetDiscount From Database
        var coupon = await dbContext.Coupons.FirstOrDefaultAsync(x => x.ProductName == request.ProductName);

        if (coupon is null)
            coupon = new Coupon { ProductName = "No discount", Amount = 0, Description = "No Descount desc" };

        logger.LogInformation($"Discount is retrieved for ProductName : {coupon.ProductName}, Amount : {coupon.Amount}");
        
        return coupon.Adapt<CouponModel>();   
    }

    public override async Task<CouponModel> CreateDiscount(CreateDiscountRequest request, 
        ServerCallContext context)
    {
        //// TODO : CreateDiscount To Database

        var coupon = request.Coupon.Adapt<Coupon>();

        if (coupon is null)
            throw new RpcException(new Status(StatusCode.InvalidArgument, "Invalid request object."));

        dbContext.Coupons.Add(coupon);
        await dbContext.SaveChangesAsync();

        logger.LogInformation($"Discount is successfully created. ProductName : {coupon.ProductName}");

        return coupon.Adapt<CouponModel>();
    }

    public override Task<CouponModel> UpdateDiscount(UpdateDiscountRequest request, 
        ServerCallContext context)
    {
        //// TODO : UpdateDiscount To Database
        return base.UpdateDiscount(request, context);
    }

    public override Task<DeleteDiscountResponse> DeleteDiscount(DeleteDiscountRequest request, 
        ServerCallContext context)
    {
        //// TODO : DeleteDiscount From Database
        return base.DeleteDiscount(request, context);
    }
}
