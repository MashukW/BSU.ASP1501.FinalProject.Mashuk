using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialNetwork.WEB.Models.LoggedModel
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
    }

    public class UserViewModelComparer : IEqualityComparer<UserViewModel>
    {
        public bool Equals(UserViewModel x, UserViewModel y)
        {
            if (ReferenceEquals(x, y))
                return true;

            return x != null && y != null && x.Email.Equals(y.Email);
        }

        public int GetHashCode(UserViewModel obj)
        {
            int hashUserId = obj.Id.GetHashCode();

            int hashUserFirstName = obj.FirstName?.GetHashCode() ?? 0;
            
            int hashUserEmail = obj.Email?.GetHashCode() ?? 0;
            
            int calculate = hashUserId ^ hashUserFirstName ^ hashUserEmail;
            return calculate;
        }
    }
}