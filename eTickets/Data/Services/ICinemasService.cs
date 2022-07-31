using eTickets.Models;

namespace eTickets.Data.Services
{
    public interface ICinemasService
    {
        Task<IEnumerable<Cinema>> GetAll();

        Cinema GetById(int CinemaId);
        void Add(int CinemaId);
        Actor Update(int CinemaId, Actor newCinema);
        void Delete(int CinemaId);
    }
}
