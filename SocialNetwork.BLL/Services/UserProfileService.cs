using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BLL.Interface.Entities;
using BLL.Interface.Services;
using DAL.Interface.DTO;
using DAL.Interface.Repository;
using static SocialNetwork.Helper.HelperConvert;

namespace BLL.Services
{
    public class UserProfileService : IUserProfileService
    {
        private readonly IUnitOfWork workRepository;

        public UserProfileService(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
                throw new ArgumentNullException(nameof(unitOfWork));

            workRepository = unitOfWork;
        }

        #region Implementation of interface methods --> IUserProfileService

        public UserProfileBLL GetProfile(UserBLL user)
        {
            if (user == null)
                return null;
            
            return EntityConvert<UserProfileDTO, UserProfileBLL>(
                workRepository.UserProfileRepository.GetProfile(user.Id));
        }
        
        public IEnumerable<UserBLL> GetAllUsersBy(Expression<Func<UserProfileBLL, bool>> predicate)
        {
            if (predicate == null)
                return null;

            IEnumerable<UserDTO> usersDto = workRepository.UserProfileRepository.GetAllUsersBy(
                    PredicateConvert<UserProfileBLL, UserProfileDTO>(predicate));

            return EntityConvert<UserDTO, UserBLL>(usersDto);
        }

        public UserProfileBLL GetById(int id)
        {
            if (id < 0)
                return null;

            UserProfileDTO userProfile = workRepository.UserProfileRepository.GetById(id);

            return EntityConvert<UserProfileDTO, UserProfileBLL>(userProfile);
        }

        public bool Update(UserProfileBLL entity)
        {
            if (entity == null)
                return false;

            UserProfileDTO userProfile = EntityConvert<UserProfileBLL, UserProfileDTO>(entity);

            var success = workRepository.UserProfileRepository.Update(userProfile);

            if (!success)
                return false;

            workRepository.Commit();

            return true;
        }

        #endregion
    }
}
