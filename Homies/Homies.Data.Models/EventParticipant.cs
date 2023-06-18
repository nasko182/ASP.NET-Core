using Microsoft.AspNetCore.Identity;

namespace Homies.Data.Models
{
    public class EventParticipant
    {
        public string HelperId { get; set; } = null!;

        public IdentityUser Helper { get; set; } = null!;

        public int EventId { get; set; }

        public Event Event { get; set; } = null!;



    }
}
