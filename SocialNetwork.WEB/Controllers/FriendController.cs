using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Providers.Entities;
using BLL.Interface.Entities;
using BLL.Interface.Services;
using SocialNetwork.WEB.Models.LoggedModel;
using static SocialNetwork.Helper.HelperConvert;

namespace SocialNetwork.WEB.Controllers
{
    [Authorize]
    public class FriendController : Controller
    {
        private readonly IUserService _userService;
        private readonly IFriendService _friendService;
        private readonly IUserProfileService _profileService;

        public FriendController(IUserService userService, IFriendService friendService, 
            IUserProfileService profileService)
        {
            _userService = userService;
            _friendService = friendService;
            _profileService = profileService;
        }

        public ActionResult Index()
        {
            var user = GetUser();

            if (user == null)
                RedirectToAction("Index", "Home");

            GetInfoAboutFriends(user.Id);

            return View();
        }

        public ActionResult ShowFriend(string id)
        {
            if (string.IsNullOrEmpty(id))
                RedirectToAction("Index", "User");

            int userId;
            int.TryParse(id, out userId);

            UserViewModel userForShow = EntityConvert<UserBLL, UserViewModel>(_userService.GetById(userId));
            ProfileViewModel profile = EntityConvert<UserProfileBLL, ProfileViewModel>(_profileService.GetById(userId));

            if (IsFriend(userForShow.Email))
                ViewBag.IsFriend = true;

            ViewBag.User = userForShow;
            
            return View(profile);
        }
        
        public ActionResult AddFriend(string userPotentialFriends)
        {
            var user = GetUser();

            int friendUserId;
            int.TryParse(userPotentialFriends, out friendUserId);

            _friendService.Add(user.Id, friendUserId);

            GetInfoAboutFriends(user.Id);

            return View("Index");
        }

        public ActionResult RemoveFriend(string userFriends)
        {
            var user = GetUser();

            int friendUserId;
            int.TryParse(userFriends, out friendUserId);

            _friendService.Remove(user.Id, friendUserId);

            GetInfoAboutFriends(user.Id);

            return View("Index");
        }

        private UserBLL GetUser()
        {
            var email = User.Identity.Name;

            return email == null ? null : _userService.GetByEmail(email);
        }

        private void GetInfoAboutFriends(int userId)
        {
            var friends = EntityConvert < UserBLL, UserViewModel>(_friendService.GetAllFriends(userId));
            var potentialFriends = EntityConvert<UserBLL, UserViewModel>(_userService.GetAll())
                                                        .Except(friends, new UserViewModelComparer());

            ViewBag.UserFriends = friends;
            ViewBag.UserPotentialFriends = potentialFriends;
        }

        private bool IsFriend(string friendEmail)
        {
            var user = GetUser();

            return user != null && _friendService.GetAllFriends(user.Id).Any(p => p.Email == friendEmail);
        }
    }
}