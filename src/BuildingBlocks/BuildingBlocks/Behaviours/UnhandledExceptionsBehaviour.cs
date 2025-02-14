using MediatR;
using Microsoft.Extensions.Logging;

namespace BuildingBlocks.Behaviours;

public class UnhandledExceptionsBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IBaseRequest
{
    private readonly ILogger<UnhandledExceptionsBehaviour<TRequest, TResponse>> _logger;
    public UnhandledExceptionsBehaviour(ILogger<UnhandledExceptionsBehaviour<TRequest, TResponse>> logger)
    {
        _logger = logger;
    }
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        try
        {
            return await next();
        }
        catch (Exception ex)
        {
            var requestName = typeof(TRequest).Name;

            _logger.LogError(ex, $"Request: Unhandled Exception request : [{typeof(TRequest).Name}] - RequestData : [{request}] - Response: [{typeof(TResponse).Name}]");

            throw;
        }
    }
}

