using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using static TaskBoard.Common.EntityValidationConstants.Task;

namespace TaskBoard.Data.Models
{
    public class Task
    {
        public Task()
        {
            this.Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        
        public DateTime CreatedOn  { get; set; }

        [Required]
        public int BoardId { get; set; }

        [Required]
        [ForeignKey(nameof(BoardId))]
        public Board? Board { get; set; }

        [Required] 
        public string OwnerId { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(OwnerId))]
        public IdentityUser User { get; set; } = null!;

    }
    
}