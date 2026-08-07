using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.Products.DTOs
{
    public sealed record ProductDto(
    int Id,
    string Name,
    string Description,
    decimal Price,
    string Currency,
    int StockQuantity,
    int CategoryId,
    string CategoryName,
    DateTime CreatedAt);
}
