﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.Interface.Entities;
using BLL.Interface.Services;
using SocialNetwork.BLL.Interface.Services;
using SocialNetwork.WEB.Models.LoggedModel;
using static SocialNetwork.Helper.HelperConvert;

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
            var users = EntityConvert<UserBLL, UserViewModel>(_searchService.Search(criterion));

            if (users != null && users.Count() > 0)
                ViewBag.SearchResult = users;

            ViewBag.Criterion = criterion;

            return View();
        }
    }
}