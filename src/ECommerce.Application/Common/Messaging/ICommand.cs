using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.Common.Messaging
{
    public interface ICommand:IRequest
    {
    }
    public interface ICommand<TResponse> : IRequest<TResponse>
    {
    }
}
