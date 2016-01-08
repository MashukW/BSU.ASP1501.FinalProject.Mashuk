using System;

namespace BLL.Interface.Entities
{
    public class UserBLL : IEntityBLL
    {
        public UserBLL()
        {

        }

        public UserBLL(int id, string email, string password, string name, DateTime creationDate)
        {
            Id = id;
            Email = email;
            Password = password;
            FirstName = name;
            CreationDate = creationDate;
        }

        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
