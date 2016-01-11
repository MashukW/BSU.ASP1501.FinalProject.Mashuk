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

        public IEnumerable<MessageBLL> GetUserAllCorrespondence(int userId)
        {
            if (userId < 0)
                return null;

            var messages = EntityConvert<MessageDTO, MessageBLL>(
                workRepository.MessageRepository.GetUserAllCorrespondence(userId));

            return AddName(messages);
        }

        public IEnumerable<MessageBLL> GetFromUserMessage(int userId)
        {
            if (userId < 0)
                return null;

            var fromUserMessage = EntityConvert<MessageDTO, MessageBLL>(
                workRepository.MessageRepository.GetFromUserMessage(userId));

            return AddName(fromUserMessage);
        }

        public IEnumerable<MessageBLL> GetToUserMessage(int userId)
        {
            if (userId < 0)
                return null;

            var toUserMessage = EntityConvert<MessageDTO, MessageBLL>(
                workRepository.MessageRepository.GetToUserMessage(userId));

            return AddName(toUserMessage);
        }

        public IEnumerable<MessageBLL> GetAllNotReaded(int userId)
        {
            throw new NotImplementedException();
            // return GetAllUserMessage(userId).Where(p => !p.ReadMessage);
        }

        public IEnumerable<MessageBLL> GetAllReaded(int userId)
        {
            throw new NotImplementedException();
            // return GetAllUserMessage(userId).Where(p => p.ReadMessage);
        }
        
        public void Readed(int messageId)
        {
            if (messageId < 0)
                return;

            workRepository.MessageRepository.ToRead(messageId);
        }

        #endregion

        #region Overridden methods of the abstract class --> BaseService

        protected override IRepository<MessageDTO> GetRepository()
        {
            return workRepository.MessageRepository;
        }

        #endregion

        private UserDTO GetUser(int userid)
        {
            return workRepository.UserRepository.GetById(userid);
        }

        private IEnumerable<MessageBLL> AddName(IEnumerable<MessageBLL> messages)
        {
            foreach (var message in messages)
            {
                message.FromUserName = GetUser(message.FromUserId).FirstName;

                if (message.ToUserId != null)
                {
                    int toUserId = message.ToUserId.Value;
                    var user = GetUser(toUserId);
                    message.ToUserName = user.FirstName;
                    message.ToUserEmail = user.Email;
                }
            }

            return messages;
        }
    }
}
