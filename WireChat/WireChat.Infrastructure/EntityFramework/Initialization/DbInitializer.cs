using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WireChat.Infrastructure.Exceptions;

namespace WireChat.Infrastructure.EntityFramework.Initialization
{
    // This class is responsible for initializing the database by applying any pending migrations.
    internal sealed class DbInitializer : IHostedService
    {
        // An instance of IServiceProvider to access required services.
        private readonly IServiceProvider _serviceProvider;

        public DbInitializer(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        private bool IsIdentityDbContext(Type type)
        {
            if (type == null || !type.IsClass) return false;

            if (type == typeof(IdentityDbContext) ||
                (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(IdentityDbContext<>)) ||
                (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(IdentityDbContext<,,>)))
            {
                return true;
            }

            return false;
        }

        //Starts the database initialization process, which applies any pending migrations.
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>A Task that represents the asynchronous operation.</returns>
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            // Retrieve all DbContext types from the current application domain.
            var dbContextTypes = AppDomain.CurrentDomain.GetAssemblies()
                   .SelectMany(assembly => assembly.GetTypes())
                   .Where(type => typeof(DbContext).IsAssignableFrom(type)
                                  && type != typeof(DbContext)
                                  && !type.IsInterface
                                  && !type.IsAbstract
                                  && !type.IsGenericTypeDefinition);

            // Create a new scope to resolve services.
            var scope = _serviceProvider.CreateScope();

            foreach (var dbContextType in dbContextTypes)
            {
                // Skip IdentityDbContext and its generic variants
                if (IsIdentityDbContext(dbContextType))
                {
                    continue;
                }

                // Resolve the DbContext instance from the service provider.
                var dbContext = scope.ServiceProvider.GetRequiredService(dbContextType) as DbContext;

                if (dbContext == null)
                {
                    throw new NullDbContextException();
                }

                Console.WriteLine($"\n\n*** Applying migrations for {dbContext} ... ***\n\n");

                // Apply any pending migrations for the current DbContext.
                await dbContext.Database.MigrateAsync(cancellationToken);

                Console.WriteLine($"\n\n*** Done! All migrations for {dbContext} are applied. ***\n\n");
            }
        }

        // Stops the database initialization process.
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>A completed Task.</returns>
        public Task StopAsync(CancellationToken cancellationToken)
            => Task.CompletedTask;
    }
}
