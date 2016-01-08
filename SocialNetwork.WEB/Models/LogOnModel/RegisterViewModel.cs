using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.WEB.Models.LogOnModel
{
    public class RegisterViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Display(Name = "Enter your First Name")]
        [Required(ErrorMessage = "The field First Name must not be empty!")]
        [StringLength(30, ErrorMessage = "First Name must contain at least {2} characters", MinimumLength = 2)]
        public string FirstName { get; set; }

        [Display(Name = "Enter your E-mail")]
        [Required(ErrorMessage = "The field E-mail must not be empty")]
        [StringLength(30, ErrorMessage = "Email must contain at least {2} characters", MinimumLength = 7)]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Incorrect E-mail")]
        public string Email { get; set; }

        [Display(Name = "Enter your password")]
        [Required(ErrorMessage = "Enter your password")]
        [StringLength(20, ErrorMessage = "The password must contain at least {2} characters", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Confirm the password")]
        [Required(ErrorMessage = "Confirm the password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords must match")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "The code from the image is required")]
        [Display(Name = "Enter the code from the image")]
        public string Captcha { get; set; }
    }
}