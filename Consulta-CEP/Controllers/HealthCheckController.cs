/*
* THE CONTROLLER's DUTY:
* Receives HTTP requests from the outside world (browsers, apps, Postman, etc.)
* Processes the request (validates, extracts data)
* Calls your business logic (use cases in Application layer)
* Returns HTTP responses (JSON, status codes)
*/

using Microsoft.AspNetCore.Mvc; // Its like Java, you use it so you dont need to write the whole thing

namespace Consulta_CEP.Controllers // This only changes the name, but ASP.NET expects controllers to be in a .Controllers namespace
{
    [ApiController] // Thats an attribute that tells ASP.NET that this class is a controller, and this adds some features to it
    // now you need to map it so so the API know where to find it
    [Route("api/[controller]")] // Another attribute that tells ASP.NET that this controller will be accessed at the /api/healthcheck endpoint
    
    public class HealthCheckController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var response = new
            {
                status = "Healthy",
                timestamp = DateTime.UtcNow,
                service = "Consulta CEP API"
            };

            return Ok(response);
        }
    }
}
