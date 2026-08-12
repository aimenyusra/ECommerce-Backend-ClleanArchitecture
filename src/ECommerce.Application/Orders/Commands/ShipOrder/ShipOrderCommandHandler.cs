using ECommerce.Application.Common.Interfaces;
using ECommerce.Application.Common.Messaging;
using ECommerce.Domain.Exceptions;

namespace ECommerce.Application.Orders.Commands.ShipOrder;

public sealed class ShipOrderCommandHandler : ICommandHandler<ShipOrderCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public ShipOrderCommandHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

    public async Task Handle(ShipOrderCommand request, CancellationToken cancellationToken)
    {
        var order = await _unitOfWork.Orders.GetByIdAsync(request.OrderId, cancellationToken);
        if (order is null)
            throw new OrderNotFoundException(request.OrderId);

        order.MarkAsShipped();
        _unitOfWork.Orders.Update(order);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}