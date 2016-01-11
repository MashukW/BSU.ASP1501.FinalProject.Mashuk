using System.Collections.Generic;
using BLL.Interface.Entities;
using BLL.Interface.Services.ServiceCollective;

namespace BLL.Interface.Services
{
    public interface IMessageService : IBaseService<MessageBLL>
    {
        IEnumerable<MessageBLL> GetUserAllCorrespondence(int userId);
        IEnumerable<MessageBLL> GetFromUserMessage(int userId);
        IEnumerable<MessageBLL> GetToUserMessage(int userId);
        IEnumerable<MessageBLL> GetAllReaded(int userId);
        IEnumerable<MessageBLL> GetAllNotReaded(int userId);
        void Readed(int message);
    }
}
