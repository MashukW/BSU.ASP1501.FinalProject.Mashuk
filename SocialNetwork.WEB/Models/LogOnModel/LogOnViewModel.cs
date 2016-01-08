using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.WEB.Models.LogOnModel
{
    public class LogOnViewModel
    {
        [Required(ErrorMessage = "Email can not be empty!")]
        [Display(Name = "Enter your Email")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Incorrect Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password can not be empty")]
        [DataType(DataType.Password)]
        [Display(Name = "Entre your password")]
        public string Password { get; set; }

        [Display(Name = "Remember password?")]
        public bool RememberMe { get; set; }
    }
}