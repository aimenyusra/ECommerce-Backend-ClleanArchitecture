using ECommerce.Application.Common.Messaging;

namespace ECommerce.Application.Cart.Commands.RemoveItemFromCart;

public sealed record RemoveItemFromCartCommand(Guid CustomerId, int ProductId) : ICommand;