using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Security;
using System.Web.Mvc;
using BLL.Interface.Entities;
using BLL.Interface.Services;

namespace SocialNetwork.WEB.Providers
{
    public class SNMembershipProvider : MembershipProvider
    {
        #region Properties

        public IUserService UserService
            => (IUserService)System.Web.Mvc.DependencyResolver.Current.GetService(typeof(IUserService));

        public IRoleService RoleService
            => (IRoleService)System.Web.Mvc.DependencyResolver.Current.GetService(typeof(IRoleService));

        #endregion

        public override bool ValidateUser(string email, string password)
        {
            bool isValid = false;

            try
            {
                var user = UserService.GetByEmail(email);

                if (user != null && Crypto.VerifyHashedPassword(user.Password, password))
                    isValid = true;
            }
            catch
            {
                isValid = false;
            }
            
            return isValid;
        }

        public MembershipUser CreateUser(string name, string email, string password)
        {
            if (UserService.ToConfirmation(email))
                return null;
            
            var user = new UserBLL()
            {
                Email = email.ToLowerInvariant(),
                Password = Crypto.HashPassword(password),
                CreationDate = DateTime.Now,
                FirstName = name
            };

            UserService.CreateUserWithRole(user, 1);
            return GetUser(email, false);
        }
        
        public override MembershipUser GetUser(string email, bool userIsOnline)
        {
            try
            {
                var user = UserService.GetByEmail(email);

                if (user == null)
                    return null;

                var memberUser = new MembershipUser("SNMembershipProvider", user.Email,
                null, null, null, null,
                false, false, user.CreationDate,
                DateTime.MinValue, DateTime.MinValue,
                DateTime.MinValue, DateTime.MinValue);

                return memberUser;
            }
            catch
            {
                return null;
            }
        }

        #region Stub
        public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer,
            bool isApproved, object providerUserKey, out MembershipCreateStatus status)
        {
            throw new NotImplementedException();
        }

        public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion,
            string newPasswordAnswer)
        {
            throw new NotImplementedException();
        }

        public override string GetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            throw new NotImplementedException();
        }

        public override string ResetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override void UpdateUser(MembershipUser user)
        {
            throw new NotImplementedException();
        }
        
        public override bool UnlockUser(string userName)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            throw new NotImplementedException();
        }
        
        public override string GetUserNameByEmail(string email)
        {
            throw new NotImplementedException();
        }
        
        public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override int GetNumberOfUsersOnline()
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override bool EnablePasswordRetrieval { get; }
        public override bool EnablePasswordReset { get; }
        public override bool RequiresQuestionAndAnswer { get; }
        public override string ApplicationName { get; set; }
        public override int MaxInvalidPasswordAttempts { get; }
        public override int PasswordAttemptWindow { get; }
        public override bool RequiresUniqueEmail { get; }
        public override MembershipPasswordFormat PasswordFormat { get; }
        public override int MinRequiredPasswordLength { get; }
        public override int MinRequiredNonAlphanumericCharacters { get; }
        public override string PasswordStrengthRegularExpression { get; } 
        #endregion
    }
}