using System.Collections.Generic;
using MicroTrialFreelance.Models;

namespace MicroTrialFreelance.Services.Interfaces
{
    public interface IGenericService<TEntity> where TEntity : class
    {
        public Task<TEntity> UpdateAsync(int id, TEntity order);
        public Task<TEntity> FindByIdAsync(int id);
        public Task DeleteAsync(int id);
        public Task<int> AddAsync(TEntity item);
        public Task<IEnumerable<TEntity>> GetAllAsync();
    }
}
