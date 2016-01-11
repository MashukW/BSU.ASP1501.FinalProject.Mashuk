using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using DAL.Interface.DTO;
using DAL.Interface.Repository.RepositoryCollective;

namespace DAL.Interface.Repository
{
    public interface IUserProfileRepository : IRepositoryGetById<UserProfileDTO>
    {
        IEnumerable<UserDTO> GetAllUsersBy(Expression<Func<UserProfileDTO, bool>> predicate);
        UserProfileDTO GetProfile(int userId);
        IEnumerable<UserProfileDTO> GetAll(); 
        bool Update(UserProfileDTO entity);
    }
}
