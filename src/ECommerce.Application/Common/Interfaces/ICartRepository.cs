using System;
using System.Collections.Generic;
using System.Text;
using DomainCart = ECommerce.Domain.Entities.Cart;

namespace ECommerce.Application.Common.Interfaces
{

    public interface ICartRepository : IGenericRepository<DomainCart>
    {
        Task<DomainCart?> GetByCustomerIdAsync(Guid customerId, CancellationToken cancellationToken = default);
    }
}
