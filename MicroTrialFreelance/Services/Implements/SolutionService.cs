using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using MicroTrialFreelance.Data;
using MicroTrialFreelance.Models;
using MicroTrialFreelance.Repositories.Interfaces;
using MicroTrialFreelance.Services.Interfaces;

namespace MicroTrialFreelance.Services.Implements
{
    public class SolutionService : ISolutionService
    {
        private ISolutionRepository _repos;
        public SolutionService(ISolutionRepository repos)             
        {
            _repos = repos;
        }

        public async Task<int> AddAsync(Solution item)
        {
            return await _repos.AddAsync(item);
        }

        public async Task DeleteAsync(int id)
        {
            await _repos.DeleteAsync(id);
        }

        public async Task<Solution?> FindByIdAsync(int id)
        {
            return await _repos.FindByIdAsync(id);
        }

        public async Task<IEnumerable<Solution>> GetAllAsync()
        {
            return await _repos.GetAllAsync();
        }
        public async Task<Solution> UpdateAsync(int id, Solution order)
        {
           return await _repos.UpdateAsync(id, order);
        }


        public async Task<IEnumerable<Solution>> GetSolutionsByUserIdAsync(int id)
        {
            return await _repos.GetSolutionsByUserIdAsync(id);
        }

        public async Task<IEnumerable<Solution>> GetSolutionsByOrderIdAsync(int id)
        {
            return await _repos.GetSolutionsByOrderIdAsync(id);
        }
    }

}
