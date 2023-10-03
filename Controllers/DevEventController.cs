using AwsomeDevEvents.API.Entities;
using AwsomeDevEvents.API.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AwsomeDevEvents.API.Controllers
{
    [Route("api/dev-events")]
    [ApiController]
    public class DevEventController : ControllerBase
    {
        private readonly DevEventDbContext _context;
        public DevEventController(DevEventDbContext context ) 
        {
            _context = context;
        }

        [HttpGet("")]
        public IActionResult GetAll() 
        {
            var devEvents = _context.DevEvents.Where(d => d.IsDeleted).ToList();
            return Ok(devEvents);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid Id)
        {
            var devEvent = _context.DevEvents.SingleOrDefault(d => d.Id == Id);
            if (devEvent == null)
            {
                return NotFound();
            }
            return Ok(devEvent);

        }
        [HttpPost]
        public IActionResult Post(DevEvent devEvent)
        {
            _context.DevEvents.Add(devEvent);
            return CreatedAtAction(nameof(GetById), new {id = devEvent.Id}, devEvent);

        }
        [HttpPut("{id}")]
        public IActionResult Update(Guid id, DevEvent input)
        {
            var devEvent = _context.DevEvents.SingleOrDefault(d => d.Id == id);
            if (devEvent == null) 
            {
                return NotFound();
            }
            devEvent.Update(input.Title, input.Description, input.StartDate, input.EndDate);
            return NoContent();

        }
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id) 
        {
            var devEvent = _context.DevEvents.SingleOrDefault(d => d.Id == id);
            if (devEvent == null) 
            {
                return NotFound();
            }
            devEvent.Delete();

            return NoContent();
        }
    }
}
