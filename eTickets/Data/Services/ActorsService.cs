using eTickets.Models;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Data.Services
{
    public class ActorsService : IActorsService
    {
        private readonly AppDbContext _context;

        public ActorsService(AppDbContext context)
        {
            _context = context;
        }

        public void Add(int ActorId)
        {
            throw new NotImplementedException();
        }

        public void Delete(int ActorId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Actor>> GetAll()
        {
            var result = await _context.Actors.ToListAsync();
            return result;
        }

        public Actor GetById(int ActorId)
        {
            throw new NotImplementedException();
        }

        public Actor Update(int ActorId, Actor newActor)
        {
            throw new NotImplementedException();
        }
    }
}
