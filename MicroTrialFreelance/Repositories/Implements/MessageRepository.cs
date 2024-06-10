//using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using MicroTrialFreelance.Data;
using MicroTrialFreelance.Models;
using MicroTrialFreelance.Repositories.Interfaces;

namespace MicroTrialFreelance.Repositories.Implements
{
    public class MessageRepository : IMessageRepository
    {
        private ApplicationDbContext _dbCon;
        private DbContextOptions<ApplicationDbContext> options;
      //  private readonly IMapper mapper;
        public MessageRepository(ApplicationDbContext context,
            //IMapper mapper, 
            DbContextOptions<ApplicationDbContext> options)
        {
            _dbCon = context;
            //this.mapper = mapper;
        }

        public async Task<int> AddAsync(Message item)
        {
                await _dbCon.Messages.AddAsync(item);
                _dbCon.SaveChanges();
                return item.Id;
        }

        public async Task DeleteAsync(int id)
        {
            var model = await _dbCon.Messages.SingleOrDefaultAsync(b => b.Id == id);
            if (model is not null)
            {
                _dbCon.Messages.Remove(model);
                await _dbCon.SaveChangesAsync();
            }
            else
                throw new DirectoryNotFoundException();
        }

        public async Task<Message?> FindByIdAsync(int id)
        {
            return await _dbCon.Messages.FindAsync(id);
        }

        public async Task<IEnumerable<Message>> GetAllAsync()
        {
            return await _dbCon.Messages.ToListAsync();
        }
        public async Task<Message> UpdateAsync(int id, Message message)
        {
            if (await _dbCon.Messages.AnyAsync(p => p.Id == id))
            {
                _dbCon.Entry(message).State = EntityState.Modified;
                await _dbCon.SaveChangesAsync();

                message.Id = id;
                return message;
            }
            else
            {
                //log ex
                throw new Exception();
            }
        }


        public async Task SetMessagesReadAsync(IEnumerable<int> ids)
        {
                var items = await _dbCon.Messages.Where(e => ids.Contains(e.Id)).ToListAsync();

                items.ForEach(e => e.isRead = true);

                await _dbCon.SaveChangesAsync();
        }

        public async Task<IEnumerable<Message>> GetMessagesByUserIdAsync(int id)
        {
            return await _dbCon.Messages.Where(p => p.UserId == id).ToListAsync();
        }
    }

}
