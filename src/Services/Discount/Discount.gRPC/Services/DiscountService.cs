using Discount.gRPC.Protos;
using Grpc.Core;

namespace Discount.gRPC.Services;

public class DiscountService : DiscountProtoService.DiscountProtoServiceBase
{
    public override Task<CouponModel> GetDiscount(GetDiscountRequest request, 
        ServerCallContext context)
    {
        //// TODO : GetDiscount From Database
        return base.GetDiscount(request, context);
    }

    public override Task<CouponModel> CreateDiscount(CreateDiscountRequest request, 
        ServerCallContext context)
    {
        //// TODO : CreateDiscount To Database
        return base.CreateDiscount(request, context);
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
