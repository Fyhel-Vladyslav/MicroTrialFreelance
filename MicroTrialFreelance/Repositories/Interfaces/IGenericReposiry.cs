using System.Collections.Generic;
using MicroTrialFreelance.Models;

namespace MicroTrialFreelance.Repositories.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        public Task<TEntity> UpdateAsync(int id, TEntity order);
        public Task<TEntity> FindByIdAsync(int id);
        public Task DeleteAsync(int id);
        public Task<int> AddAsync(TEntity item);
        public Task<IEnumerable<TEntity>> GetAllAsync();
    }
}
