using ECommerce.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Domain.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; private set; } = string.Empty;
        public ICollection<Product> Products { get; private set; } = new List<Product>();
        private Category() { } // For EF Core
        private Category(string name)
        {
            Name = name;
        }
        public static Category Create(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Category name cannot be null or empty", nameof(name));
            return new Category(name);
        }
    
    }
}
