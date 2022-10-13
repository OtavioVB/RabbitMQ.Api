using Microsoft.AspNetCore.Mvc;
using RabbitService.Publisher.Services.Messenger;

namespace RabbitService.Publisher.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RabbitController : ControllerBase
    {
        [HttpGet]
        public IActionResult Publish([FromServices] RabbitMQService rabbitMQService)
        {
            rabbitMQService.PublishMessage("API", "Rabbit MQ Service");
            return StatusCode(200);
        }
    }
}