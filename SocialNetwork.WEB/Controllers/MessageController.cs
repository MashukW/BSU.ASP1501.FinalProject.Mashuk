using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.Interface.Entities;
using BLL.Interface.Services;

namespace SocialNetwork.WEB.Controllers
{
    public class MessageController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMessageService _messageService;

        public MessageController(IUserService userService, IMessageService messageService)
        {
            _userService = userService;
            _messageService = messageService;
        }

        public ActionResult Index()
        {
            var user = GetUser();

            var userMessages = _messageService.GetAll()
                                               .Where(p => p.FromUserId == user.Id)
                                               .GroupBy(p=>p.ToUserId);



            return View();
        }

        public ActionResult SendMessage(int sendUserId)
        {
            var user = GetUser();

            throw new NotImplementedException();
        }

        private UserBLL GetUser()
        {
            var email = User.Identity.Name;

            return email == null ? null : _userService.GetByEmail(email);
        }
    }
}