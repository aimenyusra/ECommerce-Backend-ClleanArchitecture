using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Domain.Exceptions
{
    public sealed class EmptyCartException : DomainException
    {
        public EmptyCartException() : base("Cart is empty.")
        {
        }
    }
}
