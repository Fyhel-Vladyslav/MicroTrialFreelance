using System.Collections.Generic;
using MicroTrialFreelance.Entities;
using MicroTrialFreelance.Models;

namespace MicroTrialFreelance.Repositories.Interfaces
{
    public interface ISolutionRepository: IGenericRepository<Solution>
    {
        public Task<IEnumerable<Solution>> GetSolutionsByOrderIdAsync(int id);
        public Task<IEnumerable<Solution>> GetSolutionsByUserIdAsync(int id);
    }
}
