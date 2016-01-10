using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.Interface.Services;
using SocialNetwork.BLL.Interface.Services;

namespace SocialNetwork.WEB.Controllers
{
    public class SearchController : Controller
    {
        private readonly ISearchService _searchService;

        public SearchController(ISearchService searchService)
        {
            _searchService = searchService;
        }

        public ActionResult SearchUsers(string criterion)
        {
            var users = _searchService.Search(criterion);

            return View();
        }
    }
}