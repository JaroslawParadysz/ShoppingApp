using Dapper;
using ShoppingApp.Application.Configuration.Queries;
using ShoppingApp.Application.SeedWork;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ShoppingApp.Application.Orders.GetOrders
{
    public class GetOrdersHandler : IQueryHandler<GetOrdersQuery, IEnumerable<OrderDto>>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public GetOrdersHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<IEnumerable<OrderDto>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
        {
            IDbConnection dbConnection = _sqlConnectionFactory.GetOpenConnection();
            const string sql = "SELECT " +
                "OrderId, " +
                "Title " +
                "FROM " +
                "Orders";
            IEnumerable<OrderDto> orders = await dbConnection.QueryAsync<OrderDto>(sql);

            return orders.ToList();
        }
    }
}
