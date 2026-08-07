using ECommerce.Application.Common.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.Orders.DTOs
{
    public sealed record OrderDto(
    int Id,
    Guid CustomerId,
    string Status,
    AddressDto ShippingAddress,
    decimal TotalAmount,
    string Currency,
    IReadOnlyList<OrderItemDto> Items,
    DateTime CreatedAt);
}
