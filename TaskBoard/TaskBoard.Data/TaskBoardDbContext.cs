using System.Reflection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TaskBoard.Data.Models;
using Task = TaskBoard.Data.Models.Task;


namespace TaskBoard.Data
{
    public class TaskBoardDbContext : IdentityDbContext<IdentityUser> 
    {
        public TaskBoardDbContext(DbContextOptions<TaskBoardDbContext> options)
            : base(options)
        {
        }

        public DbSet<Task> Tasks { get; set; } = null!;

        public DbSet<Board> Boards { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(TaskBoardDbContext)) ?? Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}