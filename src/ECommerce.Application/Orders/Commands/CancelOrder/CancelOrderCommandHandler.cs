using ECommerce.Application.Common.Interfaces;
using ECommerce.Application.Common.Messaging;
using ECommerce.Domain.Exceptions;

namespace ECommerce.Application.Orders.Commands.CancelOrder;

public sealed class CancelOrderCommandHandler : ICommandHandler<CancelOrderCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public CancelOrderCommandHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

    public async Task Handle(CancelOrderCommand request, CancellationToken cancellationToken)
    {
        var order = await _unitOfWork.Orders.GetByIdAsync(request.OrderId, cancellationToken);
        if (order is null)
            throw new OrderNotFoundException(request.OrderId);

        order.Cancel();
        _unitOfWork.Orders.Update(order);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}