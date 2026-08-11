using ECommerce.Application.Common.DTOs;
using ECommerce.Application.Common.Messaging;
using ECommerce.Application.Products.DTOs;

namespace ECommerce.Application.Products.Queries.GetProducts;

public sealed record GetProductsQuery(
    int PageNumber = 1,
    int PageSize = 20,
    int? CategoryId = null,
    string? SearchTerm = null) : IQuery<PagedResult<ProductDto>>;