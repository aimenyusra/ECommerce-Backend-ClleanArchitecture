using AutoMapper;
using ECommerce.Application.Common.DTOs;
using ECommerce.Application.Common.Interfaces;
using ECommerce.Application.Common.Messaging;
using ECommerce.Application.Products.DTOs;

namespace ECommerce.Application.Products.Queries.GetProducts;

public sealed class GetProductsQueryHandler : IQueryHandler<GetProductsQuery, PagedResult<ProductDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetProductsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<PagedResult<ProductDto>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        var (items, totalCount) = await _unitOfWork.Products.GetPagedAsync(
            request.PageNumber, request.PageSize, request.CategoryId, request.SearchTerm, cancellationToken);

        var dtos = _mapper.Map<IReadOnlyList<ProductDto>>(items);

        return new PagedResult<ProductDto>(dtos, totalCount, request.PageNumber, request.PageSize);
    }
}