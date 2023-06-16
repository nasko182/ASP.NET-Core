using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using TaskBoard.Services.Interfaces;
using TaskBoard.Web.ViewModels.Task;

namespace TaskBoard.App.Controllers
{
    public class TaskController : BaseController
    {
        private readonly ITaskBoardService _taskBoardService;

        public TaskController(ITaskBoardService taskBoardService)
        {
            this._taskBoardService = taskBoardService;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var categories = await _taskBoardService.GetBoardsNamesAsync();

            var model = new AddEditTaskViewModel()
            {
                Categories = categories
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddEditTaskViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _taskBoardService.AddTaskAsync(model,User.FindFirst(ClaimTypes.NameIdentifier).Value);

                return RedirectToAction("All", "Board");
            }

            return View(model);
        }

        public async Task<IActionResult> Details(string id)
        {
            var task =await _taskBoardService.GetTaskAsync(id);

            return View(task);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var categories = await _taskBoardService.GetBoardsNamesAsync();

            var model =await _taskBoardService.GetTaskAsync(id);

            var task = new AddEditTaskViewModel()
            {
                Categories = categories,
                Description = model.Description,
                Title = model.Title,
                BoardId = model.BoardId
            };

            return View(task);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id,AddEditTaskViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _taskBoardService.EditTaskAsync(id,model);
                 return RedirectToAction("All", "Board");
            }

            var categories = await _taskBoardService.GetBoardsNamesAsync();

            model.Categories = categories;
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            var model = _taskBoardService.GetTaskAsync(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id,int i)
        {
            if (_taskBoardService.DeleteTaskAsync(string id))
            {

            }

            return RedirectToAction("Delete");
        }
    }
}
