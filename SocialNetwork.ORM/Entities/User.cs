using System;
using System.Collections.Generic;

namespace ORM.Entities
{
    public class User :  IEntityDB
    {
        public User()
        {
            Roles = new HashSet<Role>();
            Friends = new HashSet<Friend>();
            Messages = new HashSet<Message>();
        }

        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public DateTime CreationDate { get; set; }

        public virtual UserProfile UserProfile { get; set; }
        public virtual ICollection<Role> Roles { get; set; }
        public virtual ICollection<Friend> Friends { get; set; }
        public virtual ICollection<Message> Messages { get; set; } 
    }
}
