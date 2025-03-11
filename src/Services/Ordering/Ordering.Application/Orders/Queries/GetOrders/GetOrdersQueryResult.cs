using BuildingBlocks.Pagination;
using Ordering.Application.Dtos;

namespace Ordering.Application.Orders.Queries.GetOrders;

public record GetOrdersQueryResult(PaginatedResult<OrderDto> Orders);

