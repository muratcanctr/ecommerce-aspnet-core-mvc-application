using eTickets.Models;

namespace eTickets.Data.Services
{
    public interface ICinemasService
    {
        Task<IEnumerable<Cinema>> GetAllAsync();

        Task<Cinema> GetByIdAsync(int CinemaId);
        Task AddAsync(Cinema cinema);
        Task<Cinema> UpdateAsync(int CinemaId, Cinema newCinema);
        Task DeleteAsync(int CinemaId);
    }
}
