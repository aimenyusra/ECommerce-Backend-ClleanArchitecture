using AutoMapper;
using ECommerce.Application.Common.Interfaces;
using ECommerce.Application.Common.Messaging;
using ECommerce.Application.Orders.DTOs;

namespace ECommerce.Application.Orders.Queries.GetOrdersByCustomer;

public sealed class GetOrdersByCustomerQueryHandler : IQueryHandler<GetOrdersByCustomerQuery, IReadOnlyList<OrderDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetOrdersByCustomerQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IReadOnlyList<OrderDto>> Handle(GetOrdersByCustomerQuery request, CancellationToken cancellationToken)
    {
        var orders = await _unitOfWork.Orders.GetByCustomerIdAsync(request.CustomerId, cancellationToken);
        return _mapper.Map<IReadOnlyList<OrderDto>>(orders);
    }
}