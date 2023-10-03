using AwsomeDevEvents.API.Entities;
using AwsomeDevEvents.API.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AwsomeDevEvents.API.Controllers
{
    [Route("api/[dev-events]")]
    [ApiController]
    public class DevEventController : ControllerBase
    {
        private readonly DevEventDbContext _dbContext;
        public DevEventController(DevEventDbContext context ) 
        {
            _Dbcontext = context;
        }
        [HttpGet]
        public IActionResult GetAll() 
        {
            var devEvents = _dbContext.DevEvents.Where(d => d.IsDeleted).ToList();
            return Ok(devEvents);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(Guid Id)
        {
            var devEvents = _dbContext.DevEvents.SingleOrDefault(d => d.Id == Id);
            if (devEvent == null)
            {
                return NotFound();
            }
            return Ok(devEvents);

        }
        [HttpGet]
        public IActionResult Post(DevEvent devEvent)
        {

        }
        [HttpGet("{id}")]
        public IActionResult Update(Guid id, DevEvent devEvent)
        {

        }
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id) 
        {
        }
    }
}
