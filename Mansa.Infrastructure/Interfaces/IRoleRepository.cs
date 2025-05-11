using Mansa.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mansa.Infrastructure.Interfaces
{
    public interface IRoleRepository
    {
        Task<IEnumerable<ApplicationRole>> GetAllAsync();
        Task<ApplicationRole> GetByIdAsync(Guid id);
        Task CreateAsync(ApplicationRole user);
    }
}
