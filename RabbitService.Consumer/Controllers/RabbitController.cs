using Microsoft.AspNetCore.Mvc;
using RabbitService.Consumer.Services.Messenger;

namespace RabbitService.Consumer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RabbitController : ControllerBase
    {
        [HttpGet]
        public IActionResult Consume([FromServices] RabbitMQService rabbitMQService)
        {
            return StatusCode(200);
        }
    }
}