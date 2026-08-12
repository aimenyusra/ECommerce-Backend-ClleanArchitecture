using ECommerce.Application.Common.DTOs;
using ECommerce.Application.Common.Messaging;

namespace ECommerce.Application.Orders.Commands.PlaceOrder;

public sealed record PlaceOrderCommand(Guid CustomerId, AddressDto ShippingAddress) : ICommand<int>;