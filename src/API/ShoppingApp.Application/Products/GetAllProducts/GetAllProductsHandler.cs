using Dapper;
using ShoppingApp.Application.Configuration.Queries;
using ShoppingApp.Application.SeedWork;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ShoppingApp.Application.Products.GetAllProducts
{
    public class GetAllProductsHandler : IQueryHandler<GetAllProductsQuery, IEnumerable<ProductDto>>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public GetAllProductsHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<IEnumerable<ProductDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            IDbConnection dbConnection = _sqlConnectionFactory.GetOpenConnection();
            const string sql = @"SELECT 
	                ProductId AS ProductId,
	                Name AS ProductName
                FROM Products";
            IEnumerable<ProductDto> products = await dbConnection.QueryAsync<ProductDto>(sql);

            return products.ToList();
        }
    }
}
