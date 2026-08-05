using ECommerce.Domain.Common;
using ECommerce.Domain.Exceptions;
using ECommerce.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public Money Price { get; private set; } = null!;
        public int StockQuantity { get; private set; }
        public int CategoryId { get; private set; }
        public Category? Category { get; private set; }
        private Product() { } // For EF Core
        private Product(string name, string description, Money price, int stockQuantity, int categoryId)
        {
            Name = name;
            Description = description;
            Price = price;
            StockQuantity = stockQuantity;
            CategoryId = categoryId;
        }
        public static Product Create(string name, string description, Money price, int stockQuantity, int categoryId)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Name cannot be null or empty", nameof(name));
            if (string.IsNullOrWhiteSpace(description)) throw new ArgumentException("Description cannot be null or empty", nameof(description));
            if (stockQuantity < 0) throw new ArgumentException("Stock quantity cannot be negative", nameof(stockQuantity));
            if (categoryId <= 0) throw new ArgumentException("Category ID cannot be zero or negative", nameof(categoryId));
            return new Product(name, description, price, stockQuantity, categoryId);
        }
        public void ReduceStock(int quantity)
        {
            if (quantity <= 0) throw new ArgumentException("Quantity must be greater than zero", nameof(quantity));
            if (StockQuantity < quantity) throw new InsufficientStockException(Name, StockQuantity, quantity);
            StockQuantity -= quantity;
            SetUpdatedAt();
        }
        public void UpdatePrice(Money newPrice)
        {
            if (newPrice == null) throw new ArgumentNullException(nameof(newPrice));
            Price = newPrice;
            SetUpdatedAt();
        }
    }
}
