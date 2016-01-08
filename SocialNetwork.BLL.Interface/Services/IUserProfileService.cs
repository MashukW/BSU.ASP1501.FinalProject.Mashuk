using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BLL.Interface.Entities;

namespace BLL.Interface.Services
{
    public interface IUserProfileService
    {
        IEnumerable<UserBLL> GetAllUsersBy(Expression<Func<UserProfileBLL, bool>> predicate);
        UserProfileBLL GetProfile(UserBLL user);
        UserProfileBLL GetById(int id);
        bool Update(UserProfileBLL entity);
    }
}
