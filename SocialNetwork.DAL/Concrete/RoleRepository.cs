using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using DAL.Interface.DTO;
using DAL.Interface.Repository;
using ORM.Entities;
using static SocialNetwork.Helper.HelperConvert;

namespace DAL.Concrete
{
    public class RoleRepository : BaseRepository<RoleDTO, Role>, IRoleRepository
    {
        public RoleRepository(DbContext context)
            : base(context)
        {
            
        }

        #region Implementation of interface methods --> IRoleRepository

        public IEnumerable<UserDTO> GetAllUsersInRole(string roleName)
        {
            if (roleName == null)
                return null;

            Role role = context.Set<Role>().FirstOrDefault(p => p.Name == roleName);

            if (role?.Users == null)
                return null;

            return EntityConvert<User, UserDTO>(role.Users);
        }
        
        public RoleDTO GetByName(string roleName)
        {
            if (roleName == null)
                return null;
            
            return EntityConvert<Role, RoleDTO>(
                context.Set<Role>().FirstOrDefault(p => p.Name == roleName));
        }

        #endregion

        protected override Expression<Func<Role, RoleDTO>> GetConverter()
        {
            return p => new RoleDTO()
            {
                Id = p.Id,
                Name = p.Name
            };
        }
    }
}
