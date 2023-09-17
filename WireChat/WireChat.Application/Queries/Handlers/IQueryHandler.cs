namespace WireChat.Application.Queries.Handlers
{
    /// <typeparam name="TQuery">The type of query to be handled. 
    /// It must be a class that implements the <see cref="IQuery{TResult}"/> interface.</typeparam>
    /// <typeparam name="TResult">The type of result that the query returns.</typeparam>
    public interface IQueryHandler<in TQuery, TResult> where TQuery : class, IQuery<TResult>
    {
        // Asynchronously handles the specified query and returns a result.
        Task<TResult> HandleAsync(TQuery query);
    }
}