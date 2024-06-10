using System.Collections.Generic;
using MicroTrialFreelance.Entities;
using MicroTrialFreelance.Models;

namespace MicroTrialFreelance.Repositories.Interfaces
{
    public interface IOrderRepository: IGenericRepository<Order>
    {
        public Task<IEnumerable<string>> GetNamesAsync();
        public Task<IEnumerable<Order>> SearchByNameAsync(string request);
        public Task<IEnumerable<Order>> GetOrdersByUserIdAsync(int id);
    }
}
