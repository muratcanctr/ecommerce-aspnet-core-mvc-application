using eTickets.Models;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Data.Services
{
    public class ProducersService : IProducersService
    {
        private readonly AppDbContext _context;

        public ProducersService(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Producer producer)
        {
            await _context.Producers.AddAsync(producer);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int ProducerId)
        {
            var result = await _context.Producers.FirstOrDefaultAsync(n => n.ProducerId == ProducerId);
            _context.Producers.Remove(result);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Producer>> GetAllAsync()
        {
            var result = await _context.Producers.ToListAsync();
            return result;
        }

        public async Task<Producer> GetByIdAsync(int ProducerId)
        {
            var result = await _context.Producers.FirstOrDefaultAsync(n => n.ProducerId == ProducerId);
            return result;
        }

        public async Task<Producer> UpdateAsync(int ProducerId, Producer newProducer)
        {
            _context.Update(newProducer);
            await _context.SaveChangesAsync();
            return newProducer;
        }
    }
}
