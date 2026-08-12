using AutoMapper;
using ECommerce.Application.Cart.DTOs;
using ECommerce.Application.Common.Interfaces;
using ECommerce.Application.Common.Messaging;

namespace ECommerce.Application.Cart.Queries.GetCart;

public sealed class GetCartQueryHandler : IQueryHandler<GetCartQuery, CartDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetCartQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<CartDto> Handle(GetCartQuery request, CancellationToken cancellationToken)
    {
        var cart = await _unitOfWork.Carts.GetByCustomerIdAsync(request.CustomerId, cancellationToken);

        if (cart is null)
            return new CartDto(0, request.CustomerId, Array.Empty<CartItemDto>(), 0, "USD");

        return _mapper.Map<CartDto>(cart);
    }
}