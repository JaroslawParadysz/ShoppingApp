using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ShoppingApp.Authentication.Controllers
{
    public class HomeController : ApiController
    {
        [Authorize]
        public IActionResult Get()
        {
            return Ok("Works fine!");
        }
    }
}
