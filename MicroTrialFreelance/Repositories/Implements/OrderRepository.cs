using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using MicroTrialFreelance.Data;
using MicroTrialFreelance.Models;
using MicroTrialFreelance.Repositories.Interfaces;

namespace MicroTrialFreelance.Repositories.Implements
{
    public class OrderRepository : IOrderRepository
    {
        private ApplicationDbContext _dbCon;

        public OrderRepository(ApplicationDbContext context)             
        {
            _dbCon = context;
        }

        public async Task<int> AddAsync(Order item)
        {
            try
            {
                await _dbCon.Orders.AddAsync(item);
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
            var model = await _dbCon.Orders.SingleOrDefaultAsync(b => b.Id == id);
            if (model is not null)
            {
                _dbCon.Orders.Remove(model);
                await _dbCon.SaveChangesAsync();
            }
            else
                throw new DirectoryNotFoundException();
        }

        public async Task<Order> FindByIdAsync(int id)
        {
            return await _dbCon.Orders.FindAsync(id);
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await _dbCon.Orders.ToListAsync();
        }
        public async Task<Order> UpdateAsync(int id, Order order)
        {
            if (await _dbCon.Orders.AnyAsync(p => p.Id == id))
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


        public async Task<IEnumerable<string>> GetNamesAsync()
        {
            if(await _dbCon.Orders.AnyAsync())
                return await _dbCon.Orders.Select(p => p.Name).ToListAsync();

            return null;
        }

        public async Task<IEnumerable<Order>> SearchByNameAsync(string request)
        {
            return await _dbCon.Orders.Where(p => p.Name==request).ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetOrdersByUserIdAsync(int id)
        {
            return await _dbCon.Orders.Where(p => p.OwnerId == id).ToListAsync();
        }

        
    }

}
