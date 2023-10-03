using AwsomeDevEvents.API.Entities;

namespace AwsomeDevEvents.API.Persistence
{
    public class DevEventDbContext
    {
        public List<DevEvent> DevEvents { get; set; }
        public DevEventDbContext()
        {
            DevEvents = new List<DevEvent>();
        }
    }
}
