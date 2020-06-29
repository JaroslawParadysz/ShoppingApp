using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShoppingApp.Application.Service;
using System.Threading.Tasks;

namespace ShoppingApp.API.Service
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        public IMediator _mediator;

        public ServiceController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> PopulateDb()
        {
            await _mediator.Send(new PopulateDbCommand());
            return Created(string.Empty, null);
        }
    }
}