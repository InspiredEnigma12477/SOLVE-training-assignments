using Microsoft.AspNetCore.Mvc;

namespace EmploeeAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        [HttpGet(Name = "GetWeatherForecast")]
        public ActionResult Get()
        {
            return Ok("Shivam Sakore");
        }
    }
}