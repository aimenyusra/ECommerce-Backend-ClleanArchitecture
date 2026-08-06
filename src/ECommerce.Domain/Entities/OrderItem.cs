using ECommerce.Domain.Common;
using ECommerce.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Domain.Entities
{
    public class OrderItem : BaseEntity
    {
        public int ProductId { get; private set; }
        public string ProductName { get; private set; } = string.Empty;
        public Money UnitPrice { get; private set; } = null!;
        public int Quantity { get; private set; }
        public Money LineTotal => UnitPrice.Multiply(Quantity);

        private OrderItem() { }

        private OrderItem(int productId, string productName, Money unitPrice, int quantity)
        {
            ProductId = productId;
            ProductName = productName;
            UnitPrice = unitPrice;
            Quantity = quantity;
        }

        public static OrderItem Create(int productId, string productName, Money unitPrice, int quantity)
        {
            if (quantity <= 0)
                throw new ArgumentException("Quantity must be positive.", nameof(quantity));

            return new OrderItem(productId, productName, unitPrice, quantity);
        }
    }
}
