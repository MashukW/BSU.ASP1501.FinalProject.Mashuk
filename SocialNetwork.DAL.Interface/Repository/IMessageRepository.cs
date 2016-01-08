using System.Collections.Generic;
using DAL.Interface.DTO;
using DAL.Interface.Repository.RepositoryCollective;

namespace DAL.Interface.Repository
{
    public interface IMessageRepository : IRepository<MessageDTO>
    {
        IEnumerable<MessageDTO> GetAllUserMessage(int fromUserId, int toUserId);
        void ToRead(int readMessageId);
    }
}
