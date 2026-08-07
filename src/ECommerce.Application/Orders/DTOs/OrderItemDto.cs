using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.Orders.DTOs
{
    public sealed record OrderItemDto(
     int ProductId,
     string ProductName,
     decimal UnitPrice,
     string Currency,
     int Quantity,
     decimal LineTotal);
}
