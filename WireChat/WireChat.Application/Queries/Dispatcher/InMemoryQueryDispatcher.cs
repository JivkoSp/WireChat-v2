using Microsoft.Extensions.DependencyInjection;
using WireChat.Application.Queries.Handlers;

namespace WireChat.Application.Queries.Dispatcher
{
    // This class is responsible for dispatching queries to their corresponding handlers in an in-memory context.
    internal sealed class InMemoryQueryDispatcher : IQueryDispatcher
    {
        private readonly IServiceProvider _serviceProvider;

        public InMemoryQueryDispatcher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        // Dispatches the query asynchronously and returns the result
        public async Task<TResult> DispatchAsync<TResult>(IQuery<TResult> query)
        {
            // Creates a new scope for resolving services, ensuring that they are disposed of when the scope ends
            using var scope = _serviceProvider.CreateScope();

            // Determines the type of the query handler based on the query type and the result type
            var handlerType = typeof(IQueryHandler<,>).MakeGenericType(query.GetType(), typeof(TResult));

            // Resolves the handler instance from the service provider
            var handler = scope.ServiceProvider.GetRequiredService(handlerType);

             // Invokes the HandleAsync method on the handler with the query as an argument and returns the result
            return await (Task<TResult>)handlerType.GetMethod(nameof(IQueryHandler<IQuery<TResult>, TResult>.HandleAsync))?
                .Invoke(handler, new[] { query });
        }
    }
}