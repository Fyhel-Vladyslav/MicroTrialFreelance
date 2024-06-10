using System.Collections.Generic;
using MicroTrialFreelance.Models;
using MicroTrialFreelance.Repositories.Interfaces;

namespace MicroTrialFreelance.Services.Interfaces
{
    public interface IMessageService : IGenericRepository<Message>
    {
        public Task<IEnumerable<Message>> GetMessagesByUserIdAsync(int id);
        public Task SetMessagesReadAsync(IEnumerable<int> ids);

    }
}
