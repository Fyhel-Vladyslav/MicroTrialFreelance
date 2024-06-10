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
    public class OrderService : IOrderService
    {
        private IOrderRepository _repos;
        public OrderService(IOrderRepository repos)             
        {
            _repos = repos;
        }

        public async Task<int> AddAsync(Order item)
        {
                return await _repos.AddAsync(item);
        }

        public async Task DeleteAsync(int id)
        {
            await _repos.DeleteAsync(id);
        }

        public async Task<Order> FindByIdAsync(int id)
        {
            return await _repos.FindByIdAsync(id);
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await _repos.GetAllAsync();
        }
        public async Task<Order> UpdateAsync(int id, Order order)
        {
            return await _repos.UpdateAsync(id, order);
        }

        public async Task<IEnumerable<string>> GetNamesAsync()
        {
                return await _repos.GetNamesAsync();
        }

        public async Task<IEnumerable<Order>> SearchByNameAsync(string request)
        {
            return await _repos.SearchByNameAsync(request);
        }

        public async Task<IEnumerable<Order>> GetOrdersByUserIdAsync(int id)
        {
            return await _repos.GetOrdersByUserIdAsync(id);
        }

        
    }

}
