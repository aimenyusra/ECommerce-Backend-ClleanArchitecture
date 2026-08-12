using ECommerce.Application.Common.Interfaces;
using ECommerce.Application.Common.Messaging;
using ECommerce.Domain.Exceptions;

namespace ECommerce.Application.Cart.Commands.RemoveItemFromCart;

public sealed class RemoveItemFromCartCommandHandler : ICommandHandler<RemoveItemFromCartCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public RemoveItemFromCartCommandHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

    public async Task Handle(RemoveItemFromCartCommand request, CancellationToken cancellationToken)
    {
        var cart = await _unitOfWork.Carts.GetByCustomerIdAsync(request.CustomerId, cancellationToken);
        if (cart is null)
            throw new CartNotFoundException(request.CustomerId);

        cart.RemoveItem(request.ProductId);
        _unitOfWork.Carts.Update(cart);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}