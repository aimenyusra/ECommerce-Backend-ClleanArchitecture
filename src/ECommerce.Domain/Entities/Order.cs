using ECommerce.Domain.Common;
using ECommerce.Domain.Enums;
using ECommerce.Domain.Exceptions;
using ECommerce.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Domain.Entities
{
    public class Order : BaseEntity, IAggregateRoot
    {
        private readonly List<OrderItem> _items = new();

        public Guid CustomerId { get; private set; }
        public Address ShippingAddress { get; private set; } = null!;
        public OrderStatus Status { get; private set; }
        public IReadOnlyCollection<OrderItem> Items => _items.AsReadOnly();

        public Money TotalAmount => _items
            .Select(i => i.LineTotal)
            .Aggregate(Money.Create(0), (sum, lineTotal) => sum.Add(lineTotal));

        private Order() { }

        private Order(Guid customerId, Address shippingAddress)
        {
            CustomerId = customerId;
            ShippingAddress = shippingAddress;
            Status = OrderStatus.Pending;
        }

        public static Order Create(Guid customerId, Address shippingAddress, IEnumerable<OrderItem> items)
        {
            var itemList = items.ToList();
            if (itemList.Count == 0)
                throw new EmptyCartException();

            var order = new Order(customerId, shippingAddress);
            order._items.AddRange(itemList);
            return order;
        }

        public void Confirm()
        {
            if (Status != OrderStatus.Pending)
                throw new InvalidOrderOperationException($"Cannot confirm an order in '{Status}' status.");
            Status = OrderStatus.Confirmed;
            SetUpdatedAt();
        }

        public void MarkAsShipped()
        {
            if (Status != OrderStatus.Confirmed)
                throw new InvalidOrderOperationException($"Cannot ship an order in '{Status}' status.");
            Status = OrderStatus.Shipped;
            SetUpdatedAt();
        }

        public void MarkAsDelivered()
        {
            if (Status != OrderStatus.Shipped)
                throw new InvalidOrderOperationException($"Cannot deliver an order in '{Status}' status.");
            Status = OrderStatus.Delivered;
            SetUpdatedAt();
        }

        public void Cancel()
        {
            if (Status is OrderStatus.Shipped or OrderStatus.Delivered)
                throw new InvalidOrderOperationException($"Cannot cancel an order that has already been '{Status}'.");
            Status = OrderStatus.Cancelled;
            SetUpdatedAt();
        }
    }
}
