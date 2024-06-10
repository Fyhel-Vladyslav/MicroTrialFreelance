using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using MicroTrialFreelance.Data;
using MicroTrialFreelance.Models;
using MicroTrialFreelance.Repositories.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;

namespace MicroTrialFreelance.Repositories.Implements
{
    public class SolutionRepository : ISolutionRepository
    {
        private ApplicationDbContext _dbCon;
        public SolutionRepository( ApplicationDbContext context)             
        {
            _dbCon = context;
        }

        public async Task<int> AddAsync(Solution item)
        {
            try
            {
                await _dbCon.Solutions.AddAsync(item);
                _dbCon.SaveChanges();
                return item.Id;
            } catch (Exception ex)
            {
                //log ex
                return -1;
            }
        }

        public async Task DeleteAsync(int id)
        {
            var model = await _dbCon.Solutions.SingleOrDefaultAsync(b => b.Id == id);
            if (model is not null)
            {
                _dbCon.Solutions.Remove(model);
                await _dbCon.SaveChangesAsync();
            }
            else
                throw new DirectoryNotFoundException();
        }

        public async Task<Solution?> FindByIdAsync(int id)
        {
            return await _dbCon.Solutions.FindAsync(id);
        }

        public async Task<IEnumerable<Solution>> GetAllAsync()
        {
            return await _dbCon.Solutions.ToListAsync();
        }

        public async Task<Solution> UpdateAsync(int id, Solution order)
        {
            if (await _dbCon.Solutions.AnyAsync(p => p.Id == id))
            {
                _dbCon.Entry(order).State = EntityState.Modified;
                await _dbCon.SaveChangesAsync();
                order.Id = id;
                return order;
            }
            else
            {
                //log ex
                throw new Exception();
            }
        }


        public async Task<IEnumerable<Solution>> GetSolutionsByUserIdAsync(int id)
        {
            return await _dbCon.Solutions.Where(p => p.CreatorId == id).ToListAsync();
        }

        public async Task<IEnumerable<Solution>> GetSolutionsByOrderIdAsync(int id)
        {
            return await _dbCon.Solutions.Where(p => p.OrderId == id).ToListAsync();
        }
    }

}
