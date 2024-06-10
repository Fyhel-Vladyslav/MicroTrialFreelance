using System.Collections.Generic;
using MicroTrialFreelance.Entities;
using MicroTrialFreelance.Models;
using MicroTrialFreelance.Repositories.Interfaces;

namespace MicroTrialFreelance.Services.Interfaces
{
    public interface ISolutionService: IGenericRepository<Solution>
    {
        public Task<IEnumerable<Solution>> GetSolutionsByOrderIdAsync(int id);
        public Task<IEnumerable<Solution>> GetSolutionsByUserIdAsync(int id);
    }
}
