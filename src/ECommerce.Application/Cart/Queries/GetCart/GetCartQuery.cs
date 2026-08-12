using ECommerce.Application.Common.Messaging;
using ECommerce.Application.Cart.DTOs;

namespace ECommerce.Application.Cart.Queries.GetCart;

public sealed record GetCartQuery(Guid CustomerId) : IQuery<CartDto>;