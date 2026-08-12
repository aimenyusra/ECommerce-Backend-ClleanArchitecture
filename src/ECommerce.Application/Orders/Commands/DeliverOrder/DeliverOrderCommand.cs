using ECommerce.Application.Common.Messaging;

namespace ECommerce.Application.Orders.Commands.DeliverOrder;

public sealed record DeliverOrderCommand(int OrderId) : ICommand;