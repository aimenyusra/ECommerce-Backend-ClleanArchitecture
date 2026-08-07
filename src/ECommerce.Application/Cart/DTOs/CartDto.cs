using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.Cart.DTOs
{
    public sealed record CartDto(
     int Id,
     Guid CustomerId,
     IReadOnlyList<CartItemDto> Items,
     decimal Total,
     string Currency);
}
