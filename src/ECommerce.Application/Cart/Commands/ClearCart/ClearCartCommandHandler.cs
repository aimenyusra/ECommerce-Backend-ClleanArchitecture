using ECommerce.Application.Common.Interfaces;
using ECommerce.Application.Common.Messaging;
using ECommerce.Domain.Exceptions;

namespace ECommerce.Application.Cart.Commands.ClearCart;

public sealed class ClearCartCommandHandler : ICommandHandler<ClearCartCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public ClearCartCommandHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

    public async Task Handle(ClearCartCommand request, CancellationToken cancellationToken)
    {
        var cart = await _unitOfWork.Carts.GetByCustomerIdAsync(request.CustomerId, cancellationToken);
        if (cart is null)
            throw new CartNotFoundException(request.CustomerId);

        cart.Clear();
        _unitOfWork.Carts.Update(cart);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}