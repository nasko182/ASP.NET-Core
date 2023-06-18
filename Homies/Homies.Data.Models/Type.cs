using System.ComponentModel.DataAnnotations;

using static Homies.Common.ValidationConstants.Type;

namespace Homies.Data.Models
{
    public class Type
    {
        public Type()
        {
            this.Events = new HashSet<Event>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        public IEnumerable<Event> Events { get; set; }
    }
}
