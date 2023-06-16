using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskBoard.Services.Interfaces;

namespace TaskBoard.App.Controllers
{
    public class BoardController : BaseController
    {
        private readonly ITaskBoardService _taskBoardService;

        public BoardController(ITaskBoardService taskBoardService)
        {
            this._taskBoardService = taskBoardService;
        }

        public async Task<IActionResult> All()
        {
            var boards = await _taskBoardService.GetAllBoardsAsync();

            return View(boards);
        }
    }
}
