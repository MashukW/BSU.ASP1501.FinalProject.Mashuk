using System;

namespace DAL.Interface.DTO
{
    public class MessageDTO : IEntityDAL
    {
        public MessageDTO()
        {
            
        }

        public MessageDTO(int id, string textMessage, int fromUserId, 
            int? toUserId, DateTime dateTimeMessage, bool readMessage)
        {
            Id = id;
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
