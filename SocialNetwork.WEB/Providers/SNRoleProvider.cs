using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using BLL.Interface.Entities;
using BLL.Interface.Services;

namespace SocialNetwork.WEB.Providers
{
    public class SNRoleProvider : RoleProvider
    {
        public IUserService UserService
            => (IUserService) System.Web.Mvc.DependencyResolver.Current.GetService(typeof (IUserService));

        public IRoleService RoleService
            => (IRoleService) System.Web.Mvc.DependencyResolver.Current.GetService(typeof (IRoleService));

        public override bool IsUserInRole(string email, string roleName)
        {
            bool isUserInRole = false;

            try
            {
                isUserInRole = RoleService.IsUserInRole(email, roleName);
            }
            catch
            {
                isUserInRole = false;
            }

            return isUserInRole;
        }

        public override string[] GetRolesForUser(string email)
        {
            try
            {
                return UserService.GetUserRoles(email);
            }
            catch (Exception)
            {
                return new string[] {};
            }   
        }

        public override void CreateRole(string roleName)
        {
            RoleService.Add(new RoleBLL() {Name = roleName});
        }

        #region Stub

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName { get; set; }

        #endregion
    }
}