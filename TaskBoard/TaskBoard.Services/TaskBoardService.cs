using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TaskBoard.Data;
using TaskBoard.Services.Interfaces;
using TaskBoard.Web.ViewModels;
using TaskBoard.Web.ViewModels.Board;
using TaskBoard.Web.ViewModels.Home;
using TaskBoard.Web.ViewModels.Task;

namespace TaskBoard.Services
{
    public class TaskBoardService : ITaskBoardService
    {
        private readonly TaskBoardDbContext _dbContext;

        public TaskBoardService(TaskBoardDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<HomeTasksViewModel> GetTasksCountAsync(string userId)
        {
            var boardsNames = await GetBoardsNamesAsync();

            var tasksCounts = new List<HomeBoardViewModel>();
            var tasksCount = 0;
            foreach (var boardName in boardsNames)
            {
                var tasksInBoard = await _dbContext.Tasks.CountAsync(t => t.Board.Name == boardName.Name && t.OwnerId == userId);
                tasksCount += tasksInBoard;
                tasksCounts.Add(new HomeBoardViewModel()
                {
                    BoardName = boardName.Name,
                    TaskCount = tasksInBoard
                });
            }

            return new HomeTasksViewModel()
            {
                TotalCount = tasksCount,
                BoardsWithTasksCount = tasksCounts
            };


        }

        public async Task<IEnumerable<TaskBoardModel>> GetBoardsNamesAsync()
        {
            return await _dbContext
                .Boards.Select(b => new TaskBoardModel()
                {
                    BoardId = b.Id,
                    Name = b.Name
                }).Distinct().OrderByDescending(b => b.Name).ToListAsync();
        }

        public async Task<List<AllBoardViewModel>> GetAllBoardsAsync()
        {
            var boardsNames = await GetBoardsNamesAsync();

            var boards = new List<AllBoardViewModel>();
            foreach (var boardName in boardsNames)
            {
                var tasks = await GetTasksAsync(boardName.Name);

                boards.Add(new AllBoardViewModel()
                {
                    Name = boardName.Name,
                    Tasks = tasks
                });
            }

            return boards;
        }

        public async Task AddTaskAsync(AddEditTaskViewModel model, string userId)
        {
            var task = new Data.Models.Task()
            {
                Title = model.Title,
                Description = model.Description,
                CreatedOn = DateTime.UtcNow,
                BoardId = model.BoardId,
                OwnerId = userId,
            };

            await _dbContext.Tasks.AddAsync(task);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<TaskViewModel?> GetTaskAsync(string taskId)
        {
            return await _dbContext
                .Tasks
                .Where((t => t.Id.ToString() == taskId))
                .Select(t => new TaskViewModel()
                {
                    Title = t.Title,
                    Description = t.Description,
                    OwnerId = t.OwnerId,
                    BoardName = t.Board.Name,
                    BoardId = t.Board.Id,
                    Id = t.Id.ToString(),
                    CreatedOn = t.CreatedOn,
                    OwnerName = t.User.UserName
                })
                .FirstOrDefaultAsync();
        }

        public async Task EditTaskAsync(string taskId, AddEditTaskViewModel model)
        {
            var task = await _dbContext
                .Tasks
                .Where(t => t.Id.ToString() == taskId)
                .FirstAsync();

            task.Title = model.Title;
            task.Description = model.Description;
            task.BoardId = model.BoardId;

            await _dbContext.SaveChangesAsync();
        }

        private async Task<List<TaskViewModel>> GetTasksAsync(string boardName)
        {
            return await _dbContext
                .Tasks
                .Where(t => t.Board.Name == boardName)
                .Select(t => new TaskViewModel()
                {
                    Id = t.Id.ToString(),
                    Title = t.Title,
                    Description = t.Description,
                    BoardName = t.Board.Name,
                    OwnerId = t.OwnerId
                })
                .ToListAsync();
        }
    }
}