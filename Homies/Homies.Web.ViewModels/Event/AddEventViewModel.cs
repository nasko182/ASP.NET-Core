using System.ComponentModel.DataAnnotations;

using Homies.Web.ViewModels.Type;

using static Homies.Common.ValidationConstants.Event;

namespace Homies.Web.ViewModels.Event
{
    public class AddEventViewModel
    {
        public AddEventViewModel()
        {
            this.Types = new HashSet<TypeViewModel>();
        }

        public int Id { get; set;}

        [Required]
        [StringLength(NameMaxLength,MinimumLength = NameMinLength)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        public string Description { get; set; } = null!;

        [Required]
        public DateTime Start { get; set; }

        [Required]
        public DateTime End { get; set; }

        [Required]
        public int TypeId { get; set; }

        public IEnumerable<TypeViewModel> Types { get; set; }
    }
}
