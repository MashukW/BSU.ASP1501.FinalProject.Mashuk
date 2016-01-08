using System;
using System.Linq;
using BLL.Interface.Entities;
using BLL.Interface.Services;
using DAL.Interface.DTO;
using DAL.Interface.Repository;
using DAL.Interface.Repository.RepositoryCollective;
using static SocialNetwork.Helper.HelperConvert;

namespace BLL.Services
{
    public class UserService : BaseService<UserBLL, UserDTO>, IUserService
    {
        public UserService(IUnitOfWork unitOfWork)
            :base(unitOfWork)
        {
        }

        #region Implementation of interface methods --> IUserService

        public UserBLL GetByEmail(string email)
        {
            if (email == null)
                throw new NullReferenceException(nameof(email));

            string emailToConfirm = email.ToLowerInvariant();

            var user = workRepository.UserRepository.
                GetAll().FirstOrDefault(p => p.Email == emailToConfirm);

            return user == null ? null : EntityConvert<UserDTO, UserBLL>(user);
        }

        public bool ToConfirmation(string email)
        {
            if (email == null)
                throw new NullReferenceException(nameof(email));

            return GetByEmail(email) != null;
        }

        public bool ChangePassword(string email, string currentPassword, string newPassword)
        {
            if (email == null || currentPassword == null || newPassword == null)
                return false;

            UserDTO userForChangePassword = workRepository.UserRepository.
                GetAll().
                FirstOrDefault(p => p.Email == email);

            if (userForChangePassword == null)
                return false;

            if (userForChangePassword.Password != currentPassword)
                return false;

            userForChangePassword.Password = newPassword;
            var success = workRepository.UserRepository.Update(userForChangePassword);

            if (!success)
                return false;

            workRepository.Commit();
            return true;
        }
        
        public string GetEmail(UserBLL user)
        {
            if (user == null)
                return null;

            UserDTO findUser = workRepository.UserRepository.GetById(user.Id);

            return findUser?.Email;
        }
        
        public string GetPassword(UserBLL user)
        {
            if (user == null)
                return null;

            UserDTO findUser = workRepository.UserRepository.GetById(user.Id);

            return findUser?.Password;
        }
        
        public string[] GetUserRoles(string email)
        {
            if (email == null)
                return null;

            var allUserRoles =  workRepository.UserRepository.GetRoles(email).ToArray();
            
            var roles = new string[allUserRoles.Length];

            for (var i = 0; i < allUserRoles.Length; i++)
                roles[i] = allUserRoles[i].Name;

            return roles;
        }

        public bool CreateUserWithRole(UserBLL user, int? roleId)
        {
            if (user == null || roleId == null)
                return false;

            var userForAdd = EntityConvert<UserBLL, UserDTO>(user);

            if (userForAdd == null)
                return false;

            workRepository.UserRepository.CreateUserWithRole(userForAdd, roleId);
            workRepository.Commit();
            return true;
        }

        #endregion

        #region Overridden methods of the abstract class --> BaseService

        protected override IRepository<UserDTO> GetRepository()
        {
            return workRepository.UserRepository;
        }
        
        #endregion
    }
}
