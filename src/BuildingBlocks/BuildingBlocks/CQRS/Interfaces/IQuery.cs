using MediatR;

namespace BuildingBlocks.CQRS.Interfaces;

public interface IQuery<out TResponse> : IRequest<TResponse> where TResponse : notnull
{
}
