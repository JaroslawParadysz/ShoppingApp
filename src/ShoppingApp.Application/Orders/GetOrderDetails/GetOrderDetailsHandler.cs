using ShoppingApp.Application.Configuration.Queries;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ShoppingApp.Application.Orders.GetOrderDetails
{
    public class GetOrderDetailsHandler : IQueryHandler<GetOrderDetailsQuery, OrderDto>
    {
        public Task<OrderDto> Handle(GetOrderDetailsQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
