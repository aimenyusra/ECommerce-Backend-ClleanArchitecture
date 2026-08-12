using ECommerce.Application.Common.Interfaces;
using ECommerce.Application.Common.Messaging;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Exceptions;
using ECommerce.Domain.ValueObjects;

namespace ECommerce.Application.Orders.Commands.PlaceOrder;

public sealed class PlaceOrderCommandHandler : ICommandHandler<PlaceOrderCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;

    public PlaceOrderCommandHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

    public async Task<int> Handle(PlaceOrderCommand request, CancellationToken cancellationToken)
    {
        var cart = await _unitOfWork.Carts.GetByCustomerIdAsync(request.CustomerId, cancellationToken);
        if (cart is null || cart.Items.Count == 0)
            throw new EmptyCartException();

        var orderItems = new List<OrderItem>();

        foreach (var cartItem in cart.Items)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(cartItem.ProductId, cancellationToken);
            if (product is null)
                throw new ProductNotFoundException(cartItem.ProductId);

            product.ReduceStock(cartItem.Quantity);
            _unitOfWork.Products.Update(product);

            orderItems.Add(OrderItem.Create(product.Id, product.Name, product.Price, cartItem.Quantity));
        }

        var address = Address.Create(
            request.ShippingAddress.Street,
            request.ShippingAddress.City,
            request.ShippingAddress.State,
            request.ShippingAddress.PostalCode,
            request.ShippingAddress.Country);

        var order = Order.Create(request.CustomerId, address, orderItems);
        await _unitOfWork.Orders.AddAsync(order, cancellationToken);

        cart.Clear();
        _unitOfWork.Carts.Update(cart);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return order.Id;
    }
}