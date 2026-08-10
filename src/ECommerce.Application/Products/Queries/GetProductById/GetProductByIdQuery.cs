using ECommerce.Application.Common.Messaging;
using ECommerce.Application.Products.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.Products.Queries.GetProductById
{
    public sealed record GetProductByIdQuery(int Id) : IQuery<ProductDto>;
}
