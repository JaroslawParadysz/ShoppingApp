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
            const string orderSql = "SELECT " +
                "OrderId, " +
                "Title " +
                "FROM " +
                "Orders " +
                "WHERE " +
                "OrderId = @OrderId";
            OrderDto order = await dbConnection.QuerySingleOrDefaultAsync<OrderDto>(orderSql, new { request.OrderId });

            const string orderProductsSql = "SELECT " +
                "P.Name " +
                "FROM " +
                "OrderProducts op " +
                "INNER JOIN Products P " +
                "ON OP.ProductId = P.ProductId " +
                "WHERE OrderId = @OrderId ";
            IEnumerable<OrderProductDto> orderProducts = await dbConnection.QueryAsync<OrderProductDto>(orderProductsSql, new { request.OrderId });

            order.OrderProducts = orderProducts.AsList();
            return order;
        }
    }
}
