using System.Collections.Generic;
using BLL.Interface.Entities;
using BLL.Interface.Services.ServiceCollective;

namespace BLL.Interface.Services
{
    public interface IMessageService : IBaseService<MessageBLL>
    {
        IEnumerable<MessageBLL> GetAllUserMessage(UserBLL fromUser, UserBLL toUser);
        IEnumerable<MessageBLL> GetAllReaded(UserBLL fromUser, UserBLL toUser);
        IEnumerable<MessageBLL> GetAllNotReaded(UserBLL fromUser, UserBLL toUser);
        void Readed(MessageBLL message);
    }
}
