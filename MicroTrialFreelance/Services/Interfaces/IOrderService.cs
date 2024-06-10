using System.Collections.Generic;
using MicroTrialFreelance.Entities;
using MicroTrialFreelance.Models;
using MicroTrialFreelance.Repositories.Interfaces;

namespace MicroTrialFreelance.Services.Interfaces
{
    public interface IOrderService : IGenericRepository<Order>
    {
        public Task<IEnumerable<string>> GetNamesAsync();
        public Task<IEnumerable<Order>> SearchByNameAsync(string request);
        public Task<IEnumerable<Order>> GetOrdersByUserIdAsync(int id);
    }
}
