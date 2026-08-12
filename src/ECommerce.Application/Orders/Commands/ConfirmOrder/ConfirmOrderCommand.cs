using ECommerce.Application.Common.Messaging;

namespace ECommerce.Application.Orders.Commands.ConfirmOrder;

public sealed record ConfirmOrderCommand(int OrderId) : ICommand;