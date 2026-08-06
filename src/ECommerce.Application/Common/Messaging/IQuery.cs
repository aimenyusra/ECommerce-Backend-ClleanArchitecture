using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.Common.Messaging
{
    public interface IQuery<TResponse> : IRequest<TResponse>
    {
    }
}
