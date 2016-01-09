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

        public FriendController(IUserService userService, IFriendService friendService)
        {
            _userService = userService;
            _friendService = friendService;
        }

        public ActionResult Index()
        {
            var user = GetUser();

            if (user == null)
                RedirectToAction("Index", "Home");

            var friends = GetAllFriends(user.Id);
            var potentialFriends = GetAllUser().Except(friends, new UserViewModelComparer());
            
            ViewBag.UserFriends = friends;
            ViewBag.UserPotentialFriends = potentialFriends;

            return View();
        }

        public ActionResult ShowFriend(string id)
        {
            throw new NotImplementedException();
        }

        public ActionResult AddFriend(string userPotentialFriends)
        {
            var user = GetUser();

            int friendUserId;
            int.TryParse(userPotentialFriends, out friendUserId);

            _friendService.Add(user.Id, friendUserId);

            var friends = GetAllFriends(user.Id);
            var potentialFriends = GetAllUser().Except(friends, new UserViewModelComparer());

            ViewBag.UserFriends = friends;
            ViewBag.UserPotentialFriends = potentialFriends;

            return View("Index");
        }

        public ActionResult RemoveFriend(string id)
        {
            throw new NotImplementedException();
        }

        private UserBLL GetUser()
        {
            var email = User.Identity.Name;

            return email == null ? null : _userService.GetByEmail(email);
        }

        private IEnumerable<UserViewModel> GetAllFriends(int userId)
        {
            return EntityConvert<UserBLL, UserViewModel>(_friendService.GetAllFriends(userId));
        }

        private IEnumerable<UserViewModel> GetAllUser()
        {
            return EntityConvert<UserBLL, UserViewModel>(_userService.GetAll());
        }
    }
}