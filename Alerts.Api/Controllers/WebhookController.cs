using Microsoft.AspNetCore.Mvc;

namespace Alerts.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WebhookController : ControllerBase
    {
        [HttpPost]
        public IActionResult ReceiveWebhook([FromBody] object payload)
        {
            // TODO: Add your logic here to handle the incoming payload
            // For demonstration purposes, we'll just print it to the console.
            Console.WriteLine($"Received Payload: {payload}");

            // Respond with a status code indicating success
            return Ok(new { status = "Received" });
        }
    }
    
}