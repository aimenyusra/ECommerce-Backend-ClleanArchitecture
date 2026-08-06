using ECommerce.Domain.Common;
using ECommerce.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Domain.Entities
{
    public class Cart:BaseEntity, IAggregateRoot
    {
        private readonly List<CartItem> _items = new ();
        public Guid CustomerId { get; private set; }
        public IReadOnlyCollection<CartItem> Items => _items.AsReadOnly();
        private Cart() { }
        private Cart (Guid customerId)=>CustomerId = customerId;
        public static Cart Create(Guid customerId) => new(customerId);
        public void AddItem(int productId, Money unitPrice, int quantity)
        { 
            var existing = _items.FirstOrDefault(i =>i.ProductId == productId);
            if (existing != null)
            {
                existing.IncreaseQuantity(quantity);
                return;
            }
           _items.Add(CartItem.Create(productId, unitPrice, quantity));
            SetUpdatedAt();
        }
        public void RemoveItem(int productId)
        {
            var item = _items.FirstOrDefault(i => i.ProductId == productId);
            if(item != null)
            {
                _items.Remove(item);
                SetUpdatedAt();
            }
        }
        public void Clear()
        {
            _items.Clear();
            SetUpdatedAt();
        }

    }
}
