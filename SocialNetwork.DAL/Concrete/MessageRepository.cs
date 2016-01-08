using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using DAL.Interface.DTO;
using DAL.Interface.Repository;
using ORM.Entities;
using static SocialNetwork.Helper.HelperConvert;

namespace DAL.Concrete
{
    public class MessageRepository : BaseRepository<MessageDTO, Message>, IMessageRepository
    {
        public MessageRepository(DbContext context)
            : base(context)
        {
            
        }
        
        #region Implementation of interface methods --> IMessageRepository

        public IEnumerable<MessageDTO> GetAllUserMessage(int fromUserId, int toUserId)
        {
            if (fromUserId < 0 || toUserId < 0)
                return null;

            var messagers = context.Set<Message>().Where(
                p => p.FromUserId == fromUserId && p.ToUserId == toUserId);

            return EntityConvert<Message, MessageDTO>(messagers);
        }

        public void ToRead(int readMessageId)
        {
            if (readMessageId < 0)
                return;

            Message readedMessage = GetEntity(readMessageId);

            if (readedMessage == null)
                return;

            readedMessage.ReadMessage = true;
            context.Set<Message>().AddOrUpdate(readedMessage);
        }

        #endregion
        
        #region Overridden methods of the abstract class --> BaseRepository

        public override bool Update(MessageDTO entity)
        {
            return entity?.ReadMessage != true && base.Update(entity);
        }

        protected override Expression<Func<Message, MessageDTO>> GetConverter()
        {
            return p => new MessageDTO()
            {
                Id = p.Id,
                DateTimeMessage = p.DateTimeMessage,
                FromUserId = p.FromUserId,
                ToUserId = p.ToUserId,
                TextMessage = p.TextMessage,
                ReadMessage = p.ReadMessage 
            };
        }

        #endregion
    }
}
