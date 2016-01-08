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
        
        // GET: User
        public ActionResult Index()
        {
            var email = User.Identity.Name;

            if (email == null)
                RedirectToAction("Index", "Home");

            UserBLL user = _userService.GetByEmail(email);
            var profile = EntityConvert<UserProfileBLL, ProfileViewModel>(_profileService.GetProfile(user));
            profile.Street = "Революционная";
            profile.CompanyOfWork = "Epam";
            profile.Country = "Беларусь";
            profile.DateOfBirth = new DateTime(1989, 10, 21);
            profile.MiddleName = "Викторович";
            profile.LastName = "Машук";


            return View(profile);
        }

        public ActionResult Settings()
        {
            throw new NotImplementedException();
        }
    }
}