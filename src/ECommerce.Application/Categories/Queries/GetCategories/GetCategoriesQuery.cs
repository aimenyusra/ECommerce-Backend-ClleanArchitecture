using ECommerce.Application.Categories.DTOs;
using ECommerce.Application.Common.Messaging;

namespace ECommerce.Application.Categories.Queries.GetCategories;

public sealed record GetCategoriesQuery : IQuery<IReadOnlyList<CategoryDto>>;