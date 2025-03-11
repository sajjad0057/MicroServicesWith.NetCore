
using Ordering.Application.Dtos;

namespace Ordering.Application.Orders.Queries.GetOrderByName;

public record GetOrderByNameQueryResult(IEnumerable<OrderDto> Orders);

