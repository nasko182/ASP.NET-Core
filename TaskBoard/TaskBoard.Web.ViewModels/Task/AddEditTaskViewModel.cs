using System.ComponentModel.DataAnnotations;
using static TaskBoard.Common.EntityValidationConstants.Task;

namespace TaskBoard.Web.ViewModels.Task
{
    public class AddEditTaskViewModel
    {
        public AddEditTaskViewModel()
        {
            this.Categories = new HashSet<TaskBoardModel>();
        }

        [Required]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength, ErrorMessage = "Title should be at least {2} characters long.")]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength, ErrorMessage = "Title should be at least {2} characters long.")]
        public string Description { get; set; } = null!;

        [Display(Name = "Board")]
        public int BoardId { get; set; }

        public IEnumerable<TaskBoardModel> Categories { get; set; }
    }
}
