using ECommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.Common.Interfaces
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<bool> NameExistsAsync(string name, CancellationToken cancellationToken = default);
        Task<IReadOnlyList<Product>> GetByCategoryIdAsync(int categoryId, CancellationToken cancellationToken = default);
    }
}
