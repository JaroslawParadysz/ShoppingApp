using ShoppingApp.Domain.SeedWork;
using ShoppingApp.Infrastructure.SqlServer.Database;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ShoppingApp.Infrastructure.SqlServer.Domain
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ShoppingAppContext _shoppingAppContext;

        public UnitOfWork(ShoppingAppContext shoppingAppContext)
        {
            _shoppingAppContext = shoppingAppContext;
        }

        public async Task<int> CommitAsync(CancellationToken cancellationToken = default)
        {
            return await _shoppingAppContext.SaveChangesAsync(cancellationToken);
        }
    }
}
