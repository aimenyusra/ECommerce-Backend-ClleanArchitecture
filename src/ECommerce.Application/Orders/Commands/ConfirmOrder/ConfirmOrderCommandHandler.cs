using ECommerce.Application.Common.Interfaces;
using ECommerce.Application.Common.Messaging;
using ECommerce.Domain.Exceptions;

namespace ECommerce.Application.Orders.Commands.ConfirmOrder;

public sealed class ConfirmOrderCommandHandler : ICommandHandler<ConfirmOrderCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public ConfirmOrderCommandHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

    public async Task Handle(ConfirmOrderCommand request, CancellationToken cancellationToken)
    {
        var order = await _unitOfWork.Orders.GetByIdAsync(request.OrderId, cancellationToken);
        if (order is null)
            throw new OrderNotFoundException(request.OrderId);

        order.Confirm();
        _unitOfWork.Orders.Update(order);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}