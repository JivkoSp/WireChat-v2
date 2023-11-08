﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WireChat.Application.Services.ReadServices;
using WireChat.Domain.Repositories;
using WireChat.Application.Extensions;
using WireChat.Infrastructure.EntityFramework.Contexts;
using WireChat.Infrastructure.EntityFramework.Encryption.EncryptionProvider;
using WireChat.Infrastructure.EntityFramework.Initialization;
using WireChat.Infrastructure.EntityFramework.Options;
using WireChat.Infrastructure.EntityFramework.Repositories;
using WireChat.Infrastructure.EntityFramework.Services.ReadServices;
using WireChat.Infrastructure.Automapper.Profiles;
using WireChat.Application.Commands.Handlers;
using WireChat.Infrastructure.Logging;
using WireChat.Infrastructure.Exceptions.Interfaces;
using WireChat.Infrastructure.Exceptions;
using Quartz;
using Quartz.Simpl;
using WireChat.Infrastructure.Schedulers;

namespace WireChat.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var postgresOptions = configuration.GetOptions<PostgresOptions>("Postgres");

            services.AddSingleton<IEncryptionProvider>(new EncryptionProvider("A1B2C3D4E5F60789"));

            services.AddDbContext<ReadDbContext>(options => options.UseNpgsql(postgresOptions.ConnectionString));

            services.AddDbContext<WriteDbContext>(options => options.UseNpgsql(postgresOptions.ConnectionString));

            services.AddHostedService<DbInitializer>();

            services.AddScoped<IChatRepository, PostgresChatRepository>();

            services.AddScoped<IUserRepository, PostgresUserRepository>();

            services.AddScoped<IGroupRepository, PostgresGroupRepository>();

            services.AddScoped<INotificationHubRepository, PostgresNotificationHubRepository>();

            services.AddScoped<IChatReadService, PostgresChatReadService>();

            services.AddScoped<IUserReadService, PostgresUserReadService>();

            services.AddScoped<IGroupReadService, PostgresGroupReadService>();

            services.AddScoped<INotificationHubReadService, PostgresNotificationHubReadService>();

            services.AddQueriesWithDispatcher();

            services.AddAutoMapper(configAction => {
                configAction.AddProfile<ChatMessageProfile>();
                configAction.AddProfile<ChatProfile>();
                configAction.AddProfile<ChatUserProfile>();
                configAction.AddProfile<UserContactRequestProfile>();
                configAction.AddProfile<GroupProfile>();
                configAction.AddProfile<BlockedChatUserProfile>();
                configAction.AddProfile<AcceptedContactRequestNotificationProfile>();
                configAction.AddProfile<ActiveGroupNotificationProfile>();
                configAction.AddProfile<AddedGroupMemberNotificationProfile>();
                configAction.AddProfile<BannedGroupMemberNotificationProfile>();
                configAction.AddProfile<CreatedGroupNotificationProfile>();
                configAction.AddProfile<DeclinedContactRequestNotificationProfile>();
                configAction.AddProfile<IssuedContactRequestNotificationProfile>();
                configAction.AddProfile<ReceivedContactRequestNotificationProfile>();
                configAction.AddProfile<RemovedChatMessageNotificationProfile>();
                configAction.AddProfile<RemovedGroupMemberNotificationProfile>();
                configAction.AddProfile<NotificationHubProfile>();
                configAction.AddProfile<UserProfile>();
            });

            services.AddQuartz(configurator =>
            {
                configurator.UseJobFactory<MicrosoftDependencyInjectionJobFactory>();

                var jobKey = new JobKey("DeleteChatMessagesJob");

                configurator.AddJob<DeleteChatMessagesJob>(opts => opts.WithIdentity(jobKey));

                configurator.AddTrigger(opts => opts
                    .ForJob(jobKey)
                    .WithIdentity("DeleteChatMessagesJob-trigger")
                    .StartNow()
                    .WithSimpleSchedule(x => x
                    .WithIntervalInHours(24) 
                    .RepeatForever()));
            });

            services.AddQuartzHostedService(options => options.WaitForJobsToComplete = true);

            services.TryDecorate(typeof(ICommandHandler<>), typeof(LoggingCommandHandlerDecorator<>));

            services.AddSingleton<IExceptionToResponseMapper, ExceptionToResponseMapper>();

            services.AddSignalR(opt => {

                opt.EnableDetailedErrors = true;
                opt.MaximumReceiveMessageSize = 256*1024;
            });

            return services;
        }
    }
}
