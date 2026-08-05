using ECommerce.Domain.Common;
using ECommerce.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Domain.Entities
{
    public  class CartItem :BaseEntity
    {
        public int ProductId { get; private set; }
        public Money UnitPrice { get; private set; }=null!;
        public int Quantity { get; private set; }
        public Money LineTotal =>UnitPrice.Multiply(Quantity);
        private CartItem() { } // For EF Core
        private CartItem(int productId, Money unitPrice, int quantity)
        {
            ProductId = productId;
            UnitPrice = unitPrice;
            Quantity = quantity;
        }
        public static CartItem Create(int productId, Money unitPrice, int quantity)
        {
            if (productId <= 0) throw new ArgumentException("Product ID must be greater than zero", nameof(productId));
            if (unitPrice == null) throw new ArgumentNullException(nameof(unitPrice));
            if (quantity <= 0) throw new ArgumentException("Quantity must be greater than zero", nameof(quantity));
            return new CartItem(productId, unitPrice, quantity);
        }
        public void IncreaseQuantity(int amount)
        {
            if (amount <= 0) throw new ArgumentException("Amount must be greater than zero", nameof(amount));
            Quantity += amount;
            SetUpdatedAt();
        }
    }
}
