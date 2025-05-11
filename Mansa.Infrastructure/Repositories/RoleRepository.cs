 
using Mansa.Core.Entities;
using Mansa.Infrastructure.DbContext;
using Mansa.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 

namespace Mansa.Infrastructu    .Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly ApplicationDbContext _context;

        public RoleRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ApplicationRole>> GetAllAsync() => await _context.Roles.ToListAsync();
        public async Task<ApplicationRole> GetByIdAsync(Guid id) => await _context.Roles.FindAsync(id);
        public async Task CreateAsync(ApplicationRole role)
        {
            await _context.Roles.AddAsync(role);
            await _context.SaveChangesAsync();
        }
    }
}
