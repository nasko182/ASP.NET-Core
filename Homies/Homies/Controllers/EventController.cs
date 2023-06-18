using System.Runtime.CompilerServices;
using Homies.Services.Interfaces;
using Homies.Web.ViewModels.Event;
using Microsoft.AspNetCore.Mvc;

namespace Homies.Controllers
{
    public class EventController : BaseController
    {
        private readonly IHomiesService _homiesService;

        public EventController(IHomiesService homiesService)
        {
            this._homiesService= homiesService;
        }

        public async Task<IActionResult> All()
        {
            var model = await _homiesService.GetAllEventsAsync();

            return View(model);
        }

        public async Task<IActionResult> Details()
        {
            var model = await _homiesService.GetDetailsAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var types = await _homiesService.GetAllTypesAsync();

            var model = new AddEventViewModel
            {
                Types = types
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddEventViewModel model)
        {
            var types = await _homiesService.GetAllTypesAsync();


            if (ModelState.IsValid)
            {
                await _homiesService.AddEventToAllCollectionAsync(model,GetUserId());

                return RedirectToAction("All");
            }
            model = new AddEventViewModel
            {
                Types = types
            };
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var model = await _homiesService.GetEventByIdAsync(id);

            if (model != null)
            {
                var types = await _homiesService.GetAllTypesAsync();

                model.Types = types;

                return View(model);
            }

            return RedirectToAction("All");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditEventViewModel model)
        {
            var types = await _homiesService.GetAllTypesAsync();


            try
            {
                await _homiesService.EditEventAllCollectionAsync(model, id);
            }
            catch (Exception)
            {
                model.Types = types;

                return View(model);
            }

            return RedirectToAction("All");
        }

        public async Task<IActionResult> Joined()
        {
            var model = await _homiesService.GetJoinedEventsAsync(GetUserId());

            return View(model);
        }

        public async Task<IActionResult> Join(int id)
        {
            var userId = GetUserId();

            await _homiesService.JoinEventAsync(userId, id);

            return RedirectToAction("Joined");
        }

        public async Task<IActionResult> Leave(int id)
        {
            var userId = GetUserId();

            await _homiesService.LeaveEventAsync(userId, id);

            return RedirectToAction("All");
        }
    }
}
