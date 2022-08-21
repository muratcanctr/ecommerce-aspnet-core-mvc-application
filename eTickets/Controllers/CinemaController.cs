using eTickets.Data;
using eTickets.Data.Services;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers
{
    public class CinemaController : Controller
    {
        private readonly ICinemasService _service;

        public CinemaController(ICinemasService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var allCinemas = await _service.GetAllAsync();
            return View(allCinemas);
        }
        //Get: Cinema/Create
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name,Logo,Description")] Cinema cinema)
        {
            if (!ModelState.IsValid)
            {
                return View(cinema);
            }
            await _service.AddAsync(cinema);
            return RedirectToAction(nameof(Index));
        }

        //Get:Cinema/Details
        public async Task<IActionResult> Details(int CinemaId)
        {
            var cinemaDetails = await _service.GetByIdAsync(CinemaId);

            if (cinemaDetails == null) return View("NotFound");
            return View(cinemaDetails);
        }
        //Get: Cinema/Edit
        public async Task<IActionResult> Edit(int CinemaId)
        {
            var cinemaDetails = await _service.GetByIdAsync(CinemaId);
            if (cinemaDetails == null) return View("NotFound");
            return View(cinemaDetails);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(int CinemaId, Cinema cinema)
        {
            if (!ModelState.IsValid)
            {
                return View(cinema);
            }
            await _service.UpdateAsync(CinemaId, cinema);
            return RedirectToAction(nameof(Index));
        }
        //Get: Cinema/Delete
        public async Task<IActionResult> Delete(int CinemaId)
        {
            var cinemaDetails = await _service.GetByIdAsync(CinemaId);
            if (cinemaDetails == null) return View("NotFound");
            return View(cinemaDetails);
        }


        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int CinemaId)
        {
            var cinemaDetails = await _service.GetByIdAsync(CinemaId);
            await _service.DeleteAsync(CinemaId);
            return RedirectToAction(nameof(Index));
        }
    }
}
