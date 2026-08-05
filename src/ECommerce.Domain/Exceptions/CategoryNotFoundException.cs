using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Domain.Exceptions
{
     public sealed  class CategoryNotFoundException : DomainException
    {
        public CategoryNotFoundException(int categoryId) : base($"Category with ID {categoryId} not found.")
        {
        }
    }
}
