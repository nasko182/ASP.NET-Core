using System.ComponentModel.DataAnnotations;

using static TaskBoard.Common.EntityValidationConstants.Board;

namespace TaskBoard.Data.Models
{
    public class Board
    {
        public Board()
        {
            this.Tasks = new HashSet<Task>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        public IEnumerable<Task> Tasks { get; set; }  
    }
}
