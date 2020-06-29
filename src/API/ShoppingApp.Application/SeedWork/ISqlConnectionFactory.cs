using System.Data;

namespace ShoppingApp.Application.SeedWork
{
    public interface ISqlConnectionFactory
    {
        IDbConnection GetOpenConnection();
    }
}
