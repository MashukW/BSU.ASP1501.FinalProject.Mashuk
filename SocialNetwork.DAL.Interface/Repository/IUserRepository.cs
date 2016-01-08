using System.Collections.Generic;
using DAL.Interface.DTO;
using DAL.Interface.Repository.RepositoryCollective;

namespace DAL.Interface.Repository
{
    public interface IUserRepository : IRepository<UserDTO>
    {
        IEnumerable<RoleDTO> GetRoles(string email);
        bool CreateUserWithRole(UserDTO user, int? roleId);
        bool AddToRole(int userId, int roleId);
        bool RemoveFromRole(int userId, int roleId);
    }
}
