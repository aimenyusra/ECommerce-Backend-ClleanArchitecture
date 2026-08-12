using ECommerce.Application.Common.Messaging;

namespace ECommerce.Application.Orders.Commands.CancelOrder;

public sealed record CancelOrderCommand(int OrderId) : ICommand;