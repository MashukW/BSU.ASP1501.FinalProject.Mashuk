using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.Interface.Entities;
using BLL.Interface.Services;
using SocialNetwork.WEB.Models.LoggedModel;
using static SocialNetwork.Helper.HelperConvert;

namespace SocialNetwork.WEB.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IUserProfileService _profileService;

        public UserController(IUserService userService, IUserProfileService userProfileService)
        {
            _userService = userService;
            _profileService = userProfileService;
        }
        
        public ActionResult Index()
        {
            var user = GetUser();

            if (user == null)
                RedirectToAction("Index", "Home");
            
            ViewBag.User = EntityConvert<UserBLL, UserViewModel>(user);
            
            return View(EntityConvert<UserProfileBLL, ProfileViewModel>(_profileService.GetProfile(user)));
        }
        
        public ActionResult Settings()
        {
            var user = _userService.GetByEmail(User.Identity.Name);
            ProfileViewModel profile = EntityConvert<UserProfileBLL, ProfileViewModel>(_profileService.GetProfile(user));

            return View(profile);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Settings(ProfileViewModel profile)
        {
            if (profile == null)
                return null;

            var user = GetUser();

            if (user == null)
                RedirectToAction("Index", "Home");

            profile.Id = user.Id;

            bool success = _profileService.Update(EntityConvert<ProfileViewModel, UserProfileBLL>(profile));

            if (success)
            {
                ViewBag.Success = true;
                return View(profile);
            }

            ViewBag.NotSuccess = true;
            return View(profile);
        }

        private UserBLL GetUser()
        {
            var email = User.Identity.Name;

            return email == null ? null : _userService.GetByEmail(email);
        }
    }
}