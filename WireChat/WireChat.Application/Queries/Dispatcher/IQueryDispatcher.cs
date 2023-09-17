namespace WireChat.Application.Queries.Dispatcher
{
    public interface IQueryDispatcher
    {
        // Dispatches a query asynchronously and returns the result.
        /// <typeparam name="TResult">The type of the result produced by the query.</typeparam>
        /// <param name="query">The query to be dispatched and executed.</param>
        Task<TResult> DispatchAsync<TResult>(IQuery<TResult> query);
    }
}