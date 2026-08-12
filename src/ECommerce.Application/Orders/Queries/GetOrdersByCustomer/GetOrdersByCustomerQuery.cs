using ECommerce.Application.Common.Messaging;
using ECommerce.Application.Orders.DTOs;

namespace ECommerce.Application.Orders.Queries.GetOrdersByCustomer;

public sealed record GetOrdersByCustomerQuery(Guid CustomerId) : IQuery<IReadOnlyList<OrderDto>>;