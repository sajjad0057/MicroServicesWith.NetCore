using BuildingBlocks.CQRS.Interfaces;
using Microsoft.EntityFrameworkCore;
using Ordering.Application.Data;
using Ordering.Application.Dtos;
using Ordering.Application.Extensions;
using Ordering.Domain.Entities;

namespace Ordering.Application.Orders.Queries.GetOrderByName;

public class GetOrderByNameQueryHandler(IApplicationDbContext dbContext)
    : IQueryHandler<GetOrderByNameQuery, GetOrderByNameQueryResult>
{
    public async Task<GetOrderByNameQueryResult> Handle(GetOrderByNameQuery query,
        CancellationToken cancellationToken)
    {
        ////TODO : get orders by name using dbContext
        //// return result

        var orders = await dbContext.Orders
                .Include(o => o.OrderItems)
                .AsNoTracking()
                .Where(o => o.OrderName.Value.Contains(query.Name))
                .OrderBy(o => o.OrderName.Value)
                .ToListAsync(cancellationToken);


        return new GetOrderByNameQueryResult(orders.ToOrderDtoList());
    }
}
