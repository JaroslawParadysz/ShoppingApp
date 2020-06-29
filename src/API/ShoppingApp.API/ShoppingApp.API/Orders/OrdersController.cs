using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShoppingApp.Application.Orders.GetOrderDetails;
using ShoppingApp.Application.Orders.GetOrders;
using ShoppingApp.Application.Orders.UpdateOrderDetails;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoppingApp.API.Orders
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private IMediator _mediator;

        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            IEnumerable<Application.Orders.GetOrders.OrderDto> orders = await _mediator.Send(new GetOrdersQuery());
            return Ok(orders);
        }

        [HttpGet("{orderId}")]
        public async Task<IActionResult> GetOrderAsync([FromRoute]Guid orderId)
        {
            Application.Orders.GetOrderDetails.OrderDto result = await _mediator.Send(new GetOrderDetailsQuery(orderId));
            return Ok(result);
        }

        [HttpPut("{orderId}")]
        public async Task<IActionResult> UpdateOrderDetails(
            [FromRoute]Guid orderId, 
            [FromBody]OrderRequest orderRequest)
        {
            UpdateOrderDetailsCommand command = new UpdateOrderDetailsCommand(orderId, orderRequest.Title);
            await _mediator.Send(command);
            return Ok();
        }
    }
}