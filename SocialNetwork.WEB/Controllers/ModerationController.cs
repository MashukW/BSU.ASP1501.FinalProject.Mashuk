using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SocialNetwork.WEB.Controllers
{
    [Authorize(Roles = "Moderator")]
    public class ModerationController : Controller
    {
        // GET: Moderation
        public ActionResult Index()
        {
            return View();
        }
    }
}