using Mansa.Infrastructure.DbContext;
using Mansa.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;          
using System.Text;
using System.Threading.Tasks;

namespace Mansa.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IUserRepository Users { get; private set; }
        public IRoleRepository Roles { get; private set; }

        public UnitOfWork(ApplicationDbContext context,
                          IUserRepository userRepository,
                          IRoleRepository roleRepository)
        {
            _context = context;
            Users = userRepository;
            Roles = roleRepository;
        }

        public async Task<int> SaveChangesAsync()
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    var result = await _context.SaveChangesAsync();
                    await transaction.CommitAsync();
                    return result;
                }
                catch
                {
                    await transaction.RollbackAsync();
                    throw;
                }
            }
        }


        public void Dispose()
        {
            _context.Dispose();
        }
    }

}
