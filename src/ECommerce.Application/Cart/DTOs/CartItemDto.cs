using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.Cart.DTOs
{
    public sealed record CartItemDto(
        int ProductId,
        decimal UnitPrice,
        string Currency,
        int Quantity,
        decimal LineTotal);

}
