using ECommerce.Application.Common.Messaging;

namespace ECommerce.Application.Products.Commands.UpdateProduct;

public sealed record UpdateProductCommand(
    int Id,
    string Name,
    string Description,
    decimal Price,
    string Currency,
    int StockQuantity,
    int CategoryId) : ICommand;