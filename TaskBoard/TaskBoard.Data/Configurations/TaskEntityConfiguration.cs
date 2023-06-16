using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskBoard.Data.Models;
using Task = TaskBoard.Data.Models.Task;

namespace TaskBoard.Data.Configurations
{
    internal class TaskEntityConfiguration : IEntityTypeConfiguration<Task>
    {
        public void Configure(EntityTypeBuilder<Task> builder)
        {
            builder
                .HasOne(t => t.Board)
                .WithMany(b => b.Tasks)
                .HasForeignKey(t => t.BoardId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(this.GetTasks());
        }

        public ICollection<Task> GetTasks()
        {
            ICollection<Task> tasks = new HashSet<Task>()
            {
                new Task()
                {
                    Title = "Improve CSS styles",
                    Description = "Implement Better Styling for all pages",
                    CreatedOn = DateTime.UtcNow.AddDays(-200),
                    OwnerId = "5e24fcbf-b7ac-4276-8e51-e518945d03dc",
                    BoardId = 1
                },

                new Task()
                {
                    Title = "Android Client App",
                    Description = "Create Android Client App",
                    CreatedOn = DateTime.UtcNow.AddDays(-70),
                    OwnerId = "5e24fcbf-b7ac-4276-8e51-e518945d03dc",
                    BoardId = 1
                },

                new Task()
                {
                    Title = "Desktop Client App",
                    Description = "Create Desktop Client App",
                    CreatedOn = DateTime.UtcNow.AddDays(-43),
                    OwnerId = "5e24fcbf-b7ac-4276-8e51-e518945d03dc",
                    BoardId = 2
                },
                new Task()
                {
                    Title = "Create Tasks",
                    Description = "Implement [Create Task] page for adding new tasks",
                    CreatedOn = DateTime.UtcNow.AddDays(-463),
                    OwnerId = "5e24fcbf-b7ac-4276-8e51-e518945d03dc",
                    BoardId = 3
                }
            };

            return tasks;
        }
    }
}
