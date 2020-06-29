using Dapper;
using ShoppingApp.Application.Configuration.Queries;
using ShoppingApp.Application.SeedWork;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ShoppingApp.Application.Orders.GetOrderDetails
{
    public class GetOrderDetailsHandler : IQueryHandler<GetOrderDetailsQuery, OrderDto>
    {
        private ISqlConnectionFactory _sqlConnectionFactory;

        public GetOrderDetailsHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<OrderDto> Handle(GetOrderDetailsQuery request, CancellationToken cancellationToken)
        {
            IDbConnection dbConnection = _sqlConnectionFactory.GetOpenConnection();
            const string sql = "SELECT " +
                "OrderId, " +
                "Title " +
                "FROM " +
                "Orders";
            IEnumerable<OrderDto> orders = await dbConnection.QueryAsync<OrderDto>(sql, new { request.OrderId });

            return orders.SingleOrDefault();
        }
    }
}
