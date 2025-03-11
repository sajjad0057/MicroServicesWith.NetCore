using MediatR;

namespace BuildingBlocks.CQRS.Interfaces;

public interface ICommand : ICommand<Unit>
{
}

public interface ICommand<out TResponse> : IRequest<TResponse>
{
}

