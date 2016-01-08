using System;

namespace BLL.Interface.Entities
{
    public class MessageBLL : IEntityBLL
    {
        public MessageBLL()
        {
            
        }

        public MessageBLL(int id, string textMessage, int fromUserId,   
            int? toUserId, DateTime dateTimeMessage, bool readMessage)
        {
            Id = Id;
            TextMessage = textMessage;
            FromUserId = fromUserId;
            ToUserId = toUserId;
            DateTimeMessage = dateTimeMessage;
            ReadMessage = readMessage;
        }

        public int Id { get; set; }
        public string TextMessage { get; set; }
        public int FromUserId { get; set; }
        public int? ToUserId { get; set; }
        public DateTime DateTimeMessage { get; set; }
        public bool ReadMessage { get; set; }
    }
}
