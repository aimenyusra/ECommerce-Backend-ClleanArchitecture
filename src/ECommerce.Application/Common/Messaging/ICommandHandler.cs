using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.Common.Messaging
{
    public interface ICommandHandler<TCommand> : IRequestHandler<TCommand>
      where TCommand : ICommand
    {
    }

    public interface ICommandHandler<TCommand, TResponse> : IRequestHandler<TCommand, TResponse>
        where TCommand : ICommand<TResponse>
    {
    }
}
