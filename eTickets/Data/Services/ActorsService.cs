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

        public async Task AddAsync(Actor actor)
        {
            await _context.Actors.AddAsync(actor);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int ActorId)
        {
            var result = await _context.Actors.FirstOrDefaultAsync(n => n.ActorId == ActorId);
            _context.Actors.Remove(result);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Actor>> GetAll()
        {
            var result = await _context.Actors.ToListAsync();
            return result;
        }

        public async Task<Actor> GetByIdAsync(int ActorId)
        {
            var result = await _context.Actors.FirstOrDefaultAsync(n => n.ActorId == ActorId);
            return result;
        }

        public async Task<Actor> UpdateAsync(int ActorId, Actor newActor)
        {
            _context.Update(newActor);
            await _context.SaveChangesAsync();
            return newActor;
        }
    }
}
