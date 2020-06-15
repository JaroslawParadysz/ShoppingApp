using Microsoft.AspNetCore.Mvc;

namespace ShoppingApp.API.Service
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        [HttpGet]
        public IActionResult PopulateDb()
        {

            return Created(string.Empty, null);
        }
    }
}