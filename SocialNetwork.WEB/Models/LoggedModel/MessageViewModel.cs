using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SocialNetwork.WEB.Models.LoggedModel
{
    public class MessageViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Display(Name = "To User Email")]
        public string ToUserEmail { get; set; }

        [Display(Name = "Text Message")]
        public string TextMessage { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int FromUserId { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string FromUserName { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int? ToUserId { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string ToUserName { get; set; }

        [HiddenInput(DisplayValue = false)]
        public DateTime DateTimeMessage { get; set; }

        [HiddenInput(DisplayValue = false)]
        public bool ReadMessage { get; set; }
    }
}