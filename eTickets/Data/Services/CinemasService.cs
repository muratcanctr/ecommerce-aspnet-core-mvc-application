using eTickets.Models;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Data.Services
{
    public class CinemasService : ICinemasService
    {
        private readonly AppDbContext _context;
        public CinemasService(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Cinema cinema)
        {
            await _context.Cinemas.AddAsync(cinema);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int CinemaId)
        {
            var result = await _context.Cinemas.FirstOrDefaultAsync(n => n.CinemaId == CinemaId);
            _context.Cinemas.Remove(result);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Cinema>> GetAllAsync()
        {
            var result = await _context.Cinemas.ToListAsync();
            return result;
        }

        public async Task<Cinema> GetByIdAsync(int CinemaId)
        {
            var result = await _context.Cinemas.FirstOrDefaultAsync(n => n.CinemaId == CinemaId);
            return result;
        }

        public async Task<Cinema> UpdateAsync(int CinemaId, Cinema newCinema)
        {
            _context.Update(newCinema);
            await _context.SaveChangesAsync();
            return newCinema;
        }
       
    }
}
