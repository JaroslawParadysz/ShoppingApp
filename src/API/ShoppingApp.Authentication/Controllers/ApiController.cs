using Microsoft.AspNetCore.Mvc;

namespace ShoppingApp.Authentication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public abstract class ApiController : ControllerBase
    {
    }
}
