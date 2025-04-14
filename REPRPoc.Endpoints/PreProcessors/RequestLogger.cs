using FastEndpoints;
using Microsoft.Extensions.Logging;

namespace REPRPoc.Endpoints.PreProcessors
{
    public class RequestLogger<TRequest> : IPreProcessor<TRequest>
    {
        public Task PreProcessAsync(IPreProcessorContext<TRequest> context, CancellationToken ct)
        {
            var logger = context.HttpContext.Resolve<ILogger<TRequest>>();
            logger.LogInformation("Request: {Request}; Path:{Path}", 
                context.Request?.GetType().FullName ?? string.Empty, 
                context.HttpContext.Request.Path);

            return Task.CompletedTask;
        }
    }
}
