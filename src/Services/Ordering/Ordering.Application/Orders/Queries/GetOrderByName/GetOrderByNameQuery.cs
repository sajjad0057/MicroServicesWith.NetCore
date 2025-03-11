using BuildingBlocks.CQRS.Interfaces;

namespace Ordering.Application.Orders.Queries.GetOrderByName;

public record GetOrderByNameQuery(string Name) : IQuery<GetOrderByNameQueryResult>;

