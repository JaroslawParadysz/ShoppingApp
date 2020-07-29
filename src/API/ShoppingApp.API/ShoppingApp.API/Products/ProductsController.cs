using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShoppingApp.Application.Products.GetAllProducts;

namespace ShoppingApp.API.Products
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get() 
        {
            IEnumerable<ProductDto> products = await _mediator.Send(new GetAllProductsQuery());
            return Ok(products);
        }
    }
}