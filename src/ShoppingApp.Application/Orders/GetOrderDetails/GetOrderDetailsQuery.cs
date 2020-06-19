using ShoppingApp.Application.Configuration.Queries;
using System;

namespace ShoppingApp.Application.Orders.GetOrderDetails
{
    public class GetOrderDetailsQuery : IQuery<OrderDto>
    {
        public Guid OrderId { get; set; }
    }
}
