using TaskBoard.Web.ViewModels;
using TaskBoard.Web.ViewModels.Board;
using TaskBoard.Web.ViewModels.Home;
using TaskBoard.Web.ViewModels.Task;

namespace TaskBoard.Services.Interfaces
{
    public interface ITaskBoardService
    {
        Task<HomeTasksViewModel> GetTasksCountAsync(string userId);

        Task<List<AllBoardViewModel>> GetAllBoardsAsync();

        Task<IEnumerable<TaskBoardModel>> GetBoardsNamesAsync();

        Task AddTaskAsync(AddEditTaskViewModel model,string userId);

        Task<TaskViewModel?> GetTaskAsync(string taskId);

        Task EditTaskAsync(string taskId, AddEditTaskViewModel model);
        Task<bool> DeleteTaskAsync(string id);
    }
}
