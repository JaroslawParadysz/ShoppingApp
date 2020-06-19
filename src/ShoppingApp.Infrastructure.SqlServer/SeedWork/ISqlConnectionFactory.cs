using System.Data;

namespace ShoppingApp.Infrastructure.SqlServer.SeedWork
{
    public interface ISqlConnectionFactory
    {
        IDbConnection GetOpenConnection();
    }
}
