using hangfapi.Models;
using Microsoft.AspNetCore.Mvc;

namespace hangfapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DriversController : ControllerBase
    {
        private static List<Driver> drivers = new List<Driver>();
 
        private readonly ILogger<DriversController> _logger;

        public DriversController(ILogger<DriversController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IActionResult AddDriver(Driver driver)
        {
            if (ModelState.IsValid)
            {
                drivers.Add(driver);
                return CreatedAtAction("GetDriver", new { driver.Id }, driver);
            }
            return BadRequest();
        }
        [HttpGet]
        public IActionResult GetDriver(Guid id)
        {
            var driver = drivers.FirstOrDefault(x => x.Id == id);

            if(driver == null)
            {
                return NotFound();
            }
            return Ok(driver);
        }
        [HttpDelete]
        public IActionResult DeleteDriver(Guid id)
        {
            var driver = drivers.FirstOrDefault(x => x.Id == id);

            if (driver == null)
            {
                return NotFound();
            }
            driver.Status = 0;

            return NoContent();
        }
    }
}