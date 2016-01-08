using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Profile;
using BLL.Interface.Services;

namespace SocialNetwork.WEB.Providers
{
    public class SNProfileProvider : ProfileProvider
    {
        public IUserProfileService ProfileService
            => (IUserProfileService) System.Web.Mvc.DependencyResolver.Current.GetService(typeof (IUserProfileService));

        public IUserService UserService
            => (IUserService) System.Web.Mvc.DependencyResolver.Current.GetService(typeof (IUserService));

        public override SettingsPropertyValueCollection GetPropertyValues(SettingsContext context,
            SettingsPropertyCollection collection)
        {
            SettingsPropertyValueCollection result = new SettingsPropertyValueCollection();
            if (collection.Count < 1)
                return result;

            string userEmail = (string) context["UserName"]; //Эта строка мне пока не понятна
            if (string.IsNullOrEmpty(userEmail))
                return result;

            var user = UserService.GetByEmail(userEmail);
            var profile = ProfileService.GetProfile(user);

            foreach (SettingsProperty prop in collection)
            {
                SettingsPropertyValue svp = new SettingsPropertyValue(prop)
                {
                    PropertyValue = profile.GetType().GetProperty(prop.Name).GetValue(profile, null)
                };

                result.Add(svp);
            }

            return result;
        }

        public override void SetPropertyValues(SettingsContext context, SettingsPropertyValueCollection collection)
        {
            string userEmail = (string) context["UserName"]; //Эта строка мне пока не понятна

            if (string.IsNullOrEmpty(userEmail) || collection.Count < 1)
                return;

            var user = UserService.GetByEmail(userEmail);
            var profile = ProfileService.GetProfile(user);

            if (profile == null)
                return;

            foreach (SettingsPropertyValue val in collection)
            {
                profile.GetType().GetProperty(val.Property.Name).SetValue(profile, val.PropertyValue);
            }

            ProfileService.Update(profile);
        }

        #region Stub

        public override string ApplicationName { get; set; }

        public override int DeleteProfiles(ProfileInfoCollection profiles)
        {
            throw new NotImplementedException();
        }

        public override int DeleteProfiles(string[] usernames)
        {
            throw new NotImplementedException();
        }

        public override int DeleteInactiveProfiles(ProfileAuthenticationOption authenticationOption,
            DateTime userInactiveSinceDate)
        {
            throw new NotImplementedException();
        }

        public override int GetNumberOfInactiveProfiles(ProfileAuthenticationOption authenticationOption,
            DateTime userInactiveSinceDate)
        {
            throw new NotImplementedException();
        }

        public override ProfileInfoCollection GetAllProfiles(ProfileAuthenticationOption authenticationOption,
            int pageIndex, int pageSize,
            out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override ProfileInfoCollection GetAllInactiveProfiles(ProfileAuthenticationOption authenticationOption,
            DateTime userInactiveSinceDate, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override ProfileInfoCollection FindProfilesByUserName(ProfileAuthenticationOption authenticationOption,
            string usernameToMatch,
            int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override ProfileInfoCollection FindInactiveProfilesByUserName(
            ProfileAuthenticationOption authenticationOption,
            string usernameToMatch, DateTime userInactiveSinceDate, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}