using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Domain.Exceptions
{
    public sealed class InvalidOrderOperationException : DomainException
    {
        public InvalidOrderOperationException(string message) : base(message)
        {
        }
    }
}
