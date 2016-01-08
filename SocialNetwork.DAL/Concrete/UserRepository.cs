using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using DAL.Interface.DTO;
using DAL.Interface.Repository;
using ORM.Entities;
using static SocialNetwork.Helper.HelperConvert;

namespace DAL.Concrete
{
    public class UserRepository : BaseRepository<UserDTO, User>, IUserRepository
    {
        public UserRepository(DbContext context)
            :base(context)
        {

        }

        #region Implementation of interface methods --> IUserRepository

        public IEnumerable<RoleDTO> GetRoles(string email)
        {
            if (email == null)
                return null;

            User user = context.Set<User>().FirstOrDefault(p => p.Email == email);

            if (user == null)
                return null;

            return EntityConvert<Role, RoleDTO>(user.Roles);
        }

        public bool AddToRole(int userId, int roleId)
        {
            if (userId < 0 || roleId < 0)
                return false;

            User userForAddToRole = GetEntity(userId);
            Role roleForAdd = context.Set<Role>().FirstOrDefault(p => p.Id == roleId);

            if (userForAddToRole == null || roleForAdd == null)
                return false;

            userForAddToRole.Roles.Add(roleForAdd);
            context.Set<User>().AddOrUpdate(userForAddToRole);
            return true;
        }

        public bool RemoveFromRole(int userId, int roleId)
        {
            if (userId < 0 || roleId < 0)
                return false;

            User userForRemoveFromRole = GetEntity(userId);
            Role userRole = context.Set<Role>().FirstOrDefault(p => p.Id == roleId);

            if (userForRemoveFromRole == null || userRole == null)
                return false;

            userForRemoveFromRole.Roles.Remove(userRole);
            context.Set<User>().AddOrUpdate(userForRemoveFromRole);
            return true;
        }

        public bool CreateUserWithRole(UserDTO user, int? roleId)
        {
            if (user == null)
                return false;

            User userForAdd = EntityConvert<UserDTO, User>(user);

            if (userForAdd == null)
                return false;

            if (roleId != null)
            { 
                Role roleForAdd = context.Set<Role>().FirstOrDefault(p => p.Id == roleId);
                userForAdd.Roles.Add(roleForAdd);
            }

            userForAdd.UserProfile = new UserProfile();
            
            context.Set<User>().Add(userForAdd);
            return true;
        }

        #endregion

        #region Overridden methods of the abstract class --> BaseRepository

        public override bool Add(UserDTO entity)
        {
            return CreateUserWithRole(entity, null);
        }

        public override bool Remove(int id)
        {
            if (id < 0)
                return false;

            User userForRemove = GetEntity(id);
            UserProfile profile = context.Set<UserProfile>().Find(id);

            if (userForRemove == null || profile == null)
                return false;

            context.Set<User>().Remove(userForRemove);
            context.Set<UserProfile>().Remove(profile);
            return true;
        }

        protected override Expression<Func<User, UserDTO>> GetConverter()
        {
            return p => new UserDTO()
            {
                Id = p.Id,
                Email = p.Email,
                Password = p.Password,
                FirstName = p.FirstName,
                CreationDate = p.CreationDate
            };
        }
        
        #endregion
    }
}
