using eTickets.Data;
using eTickets.Data.Services;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers
{
    public class ProducerController : Controller
    {
        private readonly IProducersService _service;

        public ProducerController(IProducersService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var allProducer = await _service.GetAllAsync();
            return View(allProducer);
        }
        //Get: Producer/Create
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName,ProfilePictureURL,Bio")] Producer producer)
        {
            if (!ModelState.IsValid)
            {
                return View(producer);
            }
            await _service.AddAsync(producer);
            return RedirectToAction(nameof(Index));
        }

        //Get:Producer/Details
        public async Task<IActionResult> Details(int ProducerId)
        {
            var actorDetails = await _service.GetByIdAsync(ProducerId);

            if (actorDetails == null) return View("NotFound");
            return View(actorDetails);
        }
        //Get: Producer/Edit
        public async Task<IActionResult> Edit(int ProducerId)
        {
            var actorDetails = await _service.GetByIdAsync(ProducerId);
            if (actorDetails == null) return View("NotFound");
            return View(actorDetails);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(int ProducerId, Producer producer)
        {
            if (!ModelState.IsValid)
            {
                return View(producer);
            }
            await _service.UpdateAsync(ProducerId, producer);
            return RedirectToAction(nameof(Index));
        }
        //Get: Actor/Delete
        public async Task<IActionResult> Delete(int ProducerId)
        {
            var producerDetails = await _service.GetByIdAsync(ProducerId);
            if (producerDetails == null) return View("NotFound");
            return View(producerDetails);
        }


        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int ProducerId)
        {
            var producerDetails = await _service.GetByIdAsync(ProducerId);
            await _service.DeleteAsync(ProducerId);
            return RedirectToAction(nameof(Index));
        }
    }
}
