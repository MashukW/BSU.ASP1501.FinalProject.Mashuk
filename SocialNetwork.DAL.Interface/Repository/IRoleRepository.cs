using System.Collections.Generic;
using DAL.Interface.DTO;
using DAL.Interface.Repository.RepositoryCollective;

namespace DAL.Interface.Repository
{
    public interface IRoleRepository : IRepository<RoleDTO>
    {
        RoleDTO GetByName(string roleName);
        IEnumerable<UserDTO> GetAllUsersInRole(string roleName);
    }
}
