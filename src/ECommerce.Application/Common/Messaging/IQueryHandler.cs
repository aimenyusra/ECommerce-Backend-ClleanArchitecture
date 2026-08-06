using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.Common.Messaging
{ 
    public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, TResponse>
            where TQuery : IQuery<TResponse>
        {
        }
    
}
