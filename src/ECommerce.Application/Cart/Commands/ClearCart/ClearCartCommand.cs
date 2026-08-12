using ECommerce.Application.Common.Messaging;

namespace ECommerce.Application.Cart.Commands.ClearCart;

public sealed record ClearCartCommand(Guid CustomerId) : ICommand;