using ShoppingApp.Application.Configuration.Queries;
using System;

namespace ShoppingApp.Application.Orders.GetOrderDetails
{
    public class GetOrderDetailsQuery : IQuery<OrderDto>
    {
        public GetOrderDetailsQuery(Guid orderId)
        {
            OrderId = orderId;
        }

        public Guid OrderId { get; private set; }
    }
}
