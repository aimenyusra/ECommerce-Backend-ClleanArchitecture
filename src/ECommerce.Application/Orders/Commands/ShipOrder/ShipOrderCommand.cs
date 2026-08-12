using ECommerce.Application.Common.Messaging;

namespace ECommerce.Application.Orders.Commands.ShipOrder;

public sealed record ShipOrderCommand(int OrderId) : ICommand;