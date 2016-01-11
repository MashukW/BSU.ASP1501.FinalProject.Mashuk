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
            Info();

            return View();
        }

        public ActionResult SendMessage(string sendUser)
        {
            ViewBag.SendUser = EntityConvert<UserBLL, UserViewModel>(GetUser(sendUser));

            return View();
        }

        [HttpPost]
        public ActionResult SendMessage(string sendUserId, string textMessage)
        {
            var fromUser = GetUser();

            int sendIdInt;
            int.TryParse(sendUserId, out sendIdInt);

            _messageService.Add(new MessageBLL()
            {
                DateTimeMessage = DateTime.Now,
                FromUserId = fromUser.Id,
                ReadMessage = false,
                TextMessage = textMessage,
                ToUserId = sendIdInt,
            });

            Info();

            return View("Index");
        }

        private UserBLL GetUser()
        {
            var email = User.Identity.Name;

            return email == null ? null : _userService.GetByEmail(email);
        }

        private UserBLL GetUser(string email)
        {
            return email == null ? null : _userService.GetByEmail(email);
        }

        private void Info()
        {
            var user = EntityConvert<UserBLL, UserViewModel>(GetUser());

            var messages = EntityConvert<MessageBLL, MessageViewModel>(
                _messageService.GetUserAllCorrespondence(user.Id))
                .GroupBy(p => p.ToUserEmail);

            if (messages.Count() > 0)
                ViewBag.Messages = messages;

            ViewBag.Person = user;
        }
    }
}