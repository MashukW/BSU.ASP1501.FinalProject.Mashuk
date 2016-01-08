using System.Collections.Generic;
using System.Linq;
using BLL.Interface.Entities;
using BLL.Interface.Services;
using DAL.Interface.DTO;
using DAL.Interface.Repository;
using DAL.Interface.Repository.RepositoryCollective;
using static SocialNetwork.Helper.HelperConvert;

namespace BLL.Services
{
    public class RoleService : BaseService<RoleBLL, RoleDTO>, IRoleService
    {
        public RoleService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        #region Implementation of interface methods --> IRoleService

        public RoleBLL GetRoleByName(string roleName)
        {
            if (roleName == null)
                return null;

            var role = workRepository.RoleRepository.GetAll().FirstOrDefault(r => r.Name == roleName);

            return EntityConvert<RoleDTO, RoleBLL>(role);
        }
        
        public IEnumerable<UserBLL> GetAllUsersInRole(RoleBLL role)
        {
            if (role == null)
                return null;

            IEnumerable<UserDTO> users = workRepository.RoleRepository.GetAllUsersInRole(role.Name);

            return EntityConvert<UserDTO, UserBLL>(users);
        }

        public bool AddUserToRole(UserBLL user, RoleBLL role)
        {
            if (user == null || role == null)
                return false;
            
            var success = workRepository.UserRepository.AddToRole(user.Id, role.Id);

            if (!success)
                return false;

            workRepository.Commit();
            return true;
        }

        public bool RemoveUserFromRole(UserBLL user, RoleBLL role)
        {
            if (user == null || role == null)
                return false;

            var success = workRepository.UserRepository.RemoveFromRole(user.Id, role.Id);

            if (!success)
                return false;

            workRepository.Commit();
            return true;
        }
        
        public bool IsUserInRole(string email, string roleName)
        {
            if (email == null || roleName == null)
                return false;

            IEnumerable<UserDTO> users = workRepository.RoleRepository.GetAllUsersInRole(roleName);

            return users != null && users.Any(u => u.Email == email);
        }
        
        #endregion

        #region Overridden methods of the abstract class --> BaseService

        protected override IRepository<RoleDTO> GetRepository()
        {
            return workRepository.RoleRepository;
        }

        #endregion
    }
}
