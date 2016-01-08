using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using DAL.Interface.DTO;
using DAL.Interface.Repository;
using ORM.Entities;
using static SocialNetwork.Helper.HelperConvert;

namespace DAL.Concrete
{
    public class UserProfileRepository : IUserProfileRepository
    {
        private readonly DbContext context;

        public UserProfileRepository(DbContext context)
        {
            if (context == null)
                throw new NullReferenceException(nameof(context));
            this.context = context;
        }
        
        #region Implementation of interface methods --> IUserRepository
        
        public UserProfileDTO GetById(int id)
        {
            return EntityConvert<UserProfile, UserProfileDTO>(
                context.Set<UserProfile>().FirstOrDefault(p=>p.Id == id));
        }

        public UserProfileDTO GetProfile(int userId)
        {
            if (userId < 0)
                return null;

            return GetById(userId);
        }

        public IEnumerable<UserDTO> GetAllUsersBy(Expression<Func<UserProfileDTO, bool>> predicate)
        {
            if (predicate == null)
                return null;

            var userProfiles =
                context.Set<UserProfile>().Include("User").Where(
                    PredicateConvert<UserProfileDTO, UserProfile>(predicate));

            List<UserDTO> users = new List<UserDTO>();

            foreach (var profile in userProfiles)
            {
                if (profile.User != null)
                    users.Add(EntityConvert<User, UserDTO>(profile.User));
            }
            
            return users;
        }
                 
        public bool Update(UserProfileDTO entity)
        {
            if (entity == null)
                return false;

            UserProfile profileToUpdate = context.Set<UserProfile>().FirstOrDefault(
                p=>p.Id == entity.Id);

            if (profileToUpdate == null)
                return false;

            PropertyInfo[] propertiesToUpdate = typeof(UserProfile).GetProperties();
            PropertyInfo[] newValuesOfProperties = typeof(UserProfileDTO).GetProperties();
            
            foreach (var prop in propertiesToUpdate)
            {
                foreach (var newValue in newValuesOfProperties)
                {

                    if (prop.Name != newValue.Name || !prop.CanWrite)
                        continue;

                    prop.SetValue(profileToUpdate, newValue.GetValue(entity));
                    break;
                }
            }

            context.Set<UserProfile>().AddOrUpdate(profileToUpdate);
            return true;
        }
        
        #endregion
    }
}
