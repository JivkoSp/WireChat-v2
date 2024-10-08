﻿using Microsoft.Extensions.Logging;
using WireChat.Application.Commands;
using WireChat.Application.Commands.Handlers;

namespace WireChat.Infrastructure.Logging
{
    // This decorator wraps the behaviour of a Command Handler and enriches it's capabilities with the ability to log information.
    // Clarification: When the command dispatcher resolves the ICommandHandler dependency it will NOT get a CommandHandler,
    // but rather this decorator with enriched behaviour that will inject the needed Command Handler.
    // Essentially this will act as a middleware at the IOC level.
    internal sealed class LoggingCommandHandlerDecorator<TCommand> : ICommandHandler<TCommand> where TCommand : class, ICommand
    {
        private readonly ICommandHandler<TCommand> _commandHandler;
        private readonly ILogger<LoggingCommandHandlerDecorator<TCommand>> _logger;

        public LoggingCommandHandlerDecorator(ICommandHandler<TCommand> commandHandler, ILogger<LoggingCommandHandlerDecorator<TCommand>> logger)
        {
            _commandHandler = commandHandler;
            _logger = logger;
        }

        public async Task HandleAsync(TCommand command)
        {
            var commandTypeName = command.GetType().Name;

            try
            {
                _logger.LogInformation($"Wirechat --> Started processing {commandTypeName} command.");

                await _commandHandler.HandleAsync(command);

                _logger.LogInformation($"Wirechat --> Finished processing {commandTypeName} command.");
            }
            catch
            {
                _logger.LogError($"Wirechat --> Failed to process {commandTypeName} command.");

                throw; // Throw the exception to the ErrorHandlerMiddleware.
            }
        }
    }
}
