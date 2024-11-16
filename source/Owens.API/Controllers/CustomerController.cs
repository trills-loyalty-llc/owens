using Microsoft.AspNetCore.Mvc;

namespace Owens.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        public CustomerController()
        {
        }

        [HttpGet("", Name = "customer-details")]
        public Task<IActionResult> Get()
        {
            var result = Ok(Guid.NewGuid());

            return Task.FromResult<IActionResult>(result);
        }
    }
}
