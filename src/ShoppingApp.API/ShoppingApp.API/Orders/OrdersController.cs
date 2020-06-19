using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShoppingApp.Application.Orders.GetOrderDetails;
using System;
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

        [HttpGet("{orderId}")]
        public async Task<IActionResult> GetOrderAsync([FromRoute]Guid orderId)
        {
            OrderDto result = await _mediator.Send(new GetOrderDetailsQuery(orderId));
            return Ok(result);
        }
    }
}