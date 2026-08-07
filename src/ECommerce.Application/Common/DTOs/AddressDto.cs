using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.Common.DTOs
{
    public sealed record AddressDto(
    string Street,
    string City,
    string State,
    string PostalCode,
    string Country);
}
