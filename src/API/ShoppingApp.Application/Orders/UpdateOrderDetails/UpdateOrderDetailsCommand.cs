using MediatR;
using ShoppingApp.Application.Configuration.Commands;
using System;

namespace ShoppingApp.Application.Orders.UpdateOrderDetails
{
    public class UpdateOrderDetailsCommand : ICommand<Unit>
    {
        public UpdateOrderDetailsCommand(Guid orderId, string title)
        {
            OrderId = orderId;
            Title = title;
        }

        public Guid OrderId { get; set; }
        public string Title { get; set; }
    }
}
