using ECommerce.Application.Common.Interfaces;
using ECommerce.Application.Common.Messaging;
using ECommerce.Domain.Exceptions;

namespace ECommerce.Application.Orders.Commands.DeliverOrder;

public sealed class DeliverOrderCommandHandler : ICommandHandler<DeliverOrderCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeliverOrderCommandHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

    public async Task Handle(DeliverOrderCommand request, CancellationToken cancellationToken)
    {
        var order = await _unitOfWork.Orders.GetByIdAsync(request.OrderId, cancellationToken);
        if (order is null)
            throw new OrderNotFoundException(request.OrderId);

        order.MarkAsDelivered();
        _unitOfWork.Orders.Update(order);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}