using eTickets.Data;
using eTickets.Data.Services;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers
{
    public class ActorController : Controller
    {
        private readonly IActorsService _service;

        public ActorController(IActorsService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var allActor = await _service.GetAll();
            return View(allActor);
        }

        //Get: Actor/Create
        public  IActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName,ProfilePictureURL,Bio")] Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }
            await _service.AddAsync(actor);
            return RedirectToAction(nameof(Index));
        }

        //Get:Actor/Details
        public async Task<IActionResult> Details(int ActorId)
        {
            var actorDetails = await _service.GetByIdAsync(ActorId);

            if (actorDetails == null) return View();
            return View(actorDetails);
        }
        //Get: Actor/Edit
        public async Task<IActionResult> Edit(int ActorId)
        {
            var actorDetails = await _service.GetByIdAsync(ActorId);
            if (actorDetails == null) return View();
            return View(actorDetails);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(int ActorId,Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }
            await _service.UpdateAsync(ActorId,actor);
            return RedirectToAction(nameof(Index));
        }
        //Get: Actor/Delete
        public async Task<IActionResult> Delete(int ActorId)
        {
            var actorDetails = await _service.GetByIdAsync(ActorId);
            if (actorDetails == null) return View();
            return View(actorDetails);
        }


        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int ActorId)
        {
            var actorDetails = await _service.GetByIdAsync(ActorId);
            await _service.DeleteAsync(ActorId);
            return RedirectToAction(nameof(Index));
        }

    }
}
