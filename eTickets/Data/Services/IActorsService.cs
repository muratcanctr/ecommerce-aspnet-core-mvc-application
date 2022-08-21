﻿using eTickets.Models;

namespace eTickets.Data.Services
{
    public interface IActorsService
    {
        Task<IEnumerable<Actor>> GetAllAsync();

        Task<Actor> GetByIdAsync(int ActorId);
        Task AddAsync(Actor actor);
        Task<Actor> UpdateAsync(int ActorId, Actor newActor);
        Task DeleteAsync(int ActorId);
    }
}
