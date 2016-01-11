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
    [Authorize(Roles = "Administrator")]
    public class AdminController : Controller
    {
        private readonly IUserService _userService;

        public AdminController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: Admin
        public ActionResult Index()
        {
            var allUsers = EntityConvert<UserBLL, UserViewModel>(_userService.GetAll());


            return View(allUsers);
        }

        public ActionResult AddRole()
        {
            throw new NotImplementedException();
        }
    }
}