using ECommerce.Application.Common.Messaging;
using ECommerce.Application.Orders.DTOs;

namespace ECommerce.Application.Orders.Queries.GetOrderById;

public sealed record GetOrderByIdQuery(int OrderId) : IQuery<OrderDto>;