using eTickets.Models;

namespace eTickets.Data.Services
{
    public interface IProducersService
    {
        Task<IEnumerable<Producer>> GetAll();

        Producer GetById(int ProducerId);
        void Add(int ProducerId);
        Producer Update(int ProducerId, Producer newProducer);
        void Delete(int ProducerId);
    }
}
