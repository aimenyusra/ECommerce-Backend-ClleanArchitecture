using ECommerce.Application.Common.Messaging;

namespace ECommerce.Application.Products.Commands.DeleteProduct;

public sealed record DeleteProductCommand(int Id) : ICommand;