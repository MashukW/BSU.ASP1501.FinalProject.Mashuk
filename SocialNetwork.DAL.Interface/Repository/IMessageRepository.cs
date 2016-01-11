using System.Collections.Generic;
using DAL.Interface.DTO;
using DAL.Interface.Repository.RepositoryCollective;

namespace DAL.Interface.Repository
{
    public interface IMessageRepository : IRepository<MessageDTO>
    {
        IEnumerable<MessageDTO> GetUserAllCorrespondence(int userId);
        IEnumerable<MessageDTO> GetFromUserMessage(int userId);
        IEnumerable<MessageDTO> GetToUserMessage(int userId);
        IEnumerable<MessageDTO> GetAllUserMessage(int userId);
        void ToRead(int readMessageId);
    }
}
