using System.Collections.Generic;
using BLL.Interface.Entities;
using BLL.Interface.Services.ServiceCollective;

namespace BLL.Interface.Services
{
    public interface IRoleService : IBaseService<RoleBLL>
    {
        RoleBLL GetRoleByName(string roleName);
        IEnumerable<UserBLL> GetAllUsersInRole(RoleBLL role);
        bool AddUserToRole(UserBLL user, RoleBLL role);
        bool RemoveUserFromRole(UserBLL user, RoleBLL role);
        bool IsUserInRole(string email, string roleName);
    }
}
