using System;

namespace ORM.Entities
{
    public class Message : IEntityDB
    {
        public int Id { get; set; }
        public string TextMessage { get; set; }
        public int FromUserId { get; set; }
        public int? ToUserId { get; set; }
        public DateTime DateTimeMessage { get; set; }
        public bool ReadMessage { get; set; }

        public virtual User FromUser { get; set; }
        public virtual User ToUser { get; set; } 
    }
}
