using System.Collections.Generic;
using MicroTrialFreelance.Entities;
using MicroTrialFreelance.Models;

namespace MicroTrialFreelance.Repositories.Interfaces
{
    public interface IMessageRepository : IGenericRepository<Message>
    {
        public Task<IEnumerable<Message>> GetMessagesByUserIdAsync(int id);
        public Task SetMessagesReadAsync(IEnumerable<int> ids);

    }
}
