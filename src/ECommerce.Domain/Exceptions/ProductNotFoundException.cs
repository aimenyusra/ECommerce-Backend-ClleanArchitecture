using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Domain.Exceptions
{
    public sealed  class ProductNotFoundException : DomainException
    {
        public ProductNotFoundException(int productId) : base($"Product with ID {productId} not found.")
        {
        }
    }
}
