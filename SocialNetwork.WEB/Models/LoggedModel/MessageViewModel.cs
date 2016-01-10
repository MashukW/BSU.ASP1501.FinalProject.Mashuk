using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialNetwork.WEB.Models.LoggedModel
{
    public class MessageViewModel
    {
        public int Id { get; set; }
        public string TextMessage { get; set; }
        public int FromUserId { get; set; }
        public int? ToUserId { get; set; }
        public DateTime DateTimeMessage { get; set; }
        public bool ReadMessage { get; set; }
    }
}