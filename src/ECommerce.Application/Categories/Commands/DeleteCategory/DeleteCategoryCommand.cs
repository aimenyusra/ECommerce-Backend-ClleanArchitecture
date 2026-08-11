using ECommerce.Application.Common.Messaging;

namespace ECommerce.Application.Categories.Commands.DeleteCategory;

public sealed record DeleteCategoryCommand(int Id) : ICommand;