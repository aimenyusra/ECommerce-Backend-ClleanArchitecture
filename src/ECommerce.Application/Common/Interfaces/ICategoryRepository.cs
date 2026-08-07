using ECommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.Common.Interfaces
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Task<bool> NameExistsAsync(string name, CancellationToken cancellationToken = default);
    }
}
