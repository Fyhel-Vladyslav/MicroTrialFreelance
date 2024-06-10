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
    public class MessageService : IMessageService
    {
        private IMessageRepository _repos;
        public MessageService(IMessageRepository repos)
        {
            _repos = repos;
        }

        public async Task<int> AddAsync(Message item)
        {
                return await _repos.AddAsync(item);
        }

        public async Task DeleteAsync(int id)
        {
            await _repos.DeleteAsync(id);
        }

        public async Task<Message> FindByIdAsync(int id)
        {
            return await _repos.FindByIdAsync(id);
        }

        public async Task<IEnumerable<Message>> GetAllAsync()
        {
            return await _repos.GetAllAsync();
        }
        public async Task<Message> UpdateAsync(int id, Message order)
        {
               return await _repos.UpdateAsync(id, order);
        }

        public async Task SetMessagesReadAsync(IEnumerable<int> ids)
        {
            if (ids != null)
            {
                await _repos.SetMessagesReadAsync(ids);
            }
        }

        public async Task<IEnumerable<Message>> GetMessagesByUserIdAsync(int id)
        {
            return await _repos.GetMessagesByUserIdAsync(id);
        }
    }

}
