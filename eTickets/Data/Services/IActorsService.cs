using eTickets.Models;

namespace eTickets.Data.Services
{
    public interface IActorsService
    {
        Task<IEnumerable<Actor>> GetAll();

        Actor GetById(int ActorId);
        void Add(int ActorId);
        Actor Update(int ActorId, Actor newActor);
        void Delete(int ActorId);
    }
}
