using ECommerce.Application.Common.Messaging;

namespace ECommerce.Application.Cart.Commands.AddItemToCart;

public sealed record AddItemToCartCommand(Guid CustomerId, int ProductId, int Quantity) : ICommand;