using eTickets.Models;

namespace eTickets.Data.Services
{
    public interface IProducersService
    {
        Task<IEnumerable<Producer>> GetAllAsync();

        Task<Producer> GetByIdAsync(int ProducerId);
        Task AddAsync(Producer producer);
        Task<Producer> UpdateAsync(int ProducerId, Producer newProducer);
        Task DeleteAsync(int ProducerId);
    }
}
