using System;
using System.Collections.Generic;
using System.Linq;
using BLL.Interface.Entities;
using BLL.Interface.Services;
using DAL.Interface.DTO;
using DAL.Interface.Repository;
using DAL.Interface.Repository.RepositoryCollective;
using static SocialNetwork.Helper.HelperConvert;

namespace BLL.Services
{
    public class MessageService : BaseService<MessageBLL, MessageDTO>, IMessageService
    {
        public MessageService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        #region Implementation of interface methods --> IMessageService

        public IEnumerable<MessageBLL> GetAllUserMessage(UserBLL fromUser, UserBLL toUser)
        {
            if (fromUser == null || toUser == null)
                return null;

            return EntityConvert<MessageDTO, MessageBLL>(
                workRepository.MessageRepository.GetAllUserMessage(fromUser.Id, toUser.Id));
        }

        public IEnumerable<MessageBLL> GetAllNotReaded(UserBLL fromUser, UserBLL toUser)
        {
            return GetAllUserMessage(fromUser, toUser).Where(p => !p.ReadMessage);
        }

        public IEnumerable<MessageBLL> GetAllReaded(UserBLL fromUser, UserBLL toUser)
        {
            return GetAllUserMessage(fromUser, toUser).Where(p => p.ReadMessage);
        }
        
        public void Readed(MessageBLL message)
        {
            if (message == null)
                return;

            workRepository.MessageRepository.ToRead(message.Id);
        }

        #endregion

        #region Overridden methods of the abstract class --> BaseService

        protected override IRepository<MessageDTO> GetRepository()
        {
            return workRepository.MessageRepository;
        }

        #endregion
    }
}
