using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SocialNetwork.WEB.Models.LoggedModel
{
    public class ProfileViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Display(Name = "Middle Name")]
        [StringLength(25, ErrorMessage = "Middle Name must contain at least {2} characters", MinimumLength = 2)]
        public string MiddleName { get; set; }

        [Display(Name = "Last Name")]
        [StringLength(25, ErrorMessage = "Last Name must contain at least {2} characters", MinimumLength = 2)]
        public string LastName { get; set; }

        [Display(Name = "Date Of Birth")]
        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }

        [StringLength(8, MinimumLength = 1)]
        public string Gender { get; set; }

        [Display(Name = "Mobile Number")]
        [StringLength(20, ErrorMessage = "Mobile Number similar ххх-хх-хх", MinimumLength = 9)]
        [DataType(DataType.PhoneNumber)]
        public string MobilePhoneNumber { get; set; }
        
        [Display(Name = "Country of Residence")]
        [StringLength(20, MinimumLength = 3)]
        public string Country { get; set; }

        [Display(Name = "City of Residence")]
        [StringLength(20, MinimumLength = 3)]
        public string City { get; set; }

        [Display(Name = "Street")]
        [StringLength(30, MinimumLength = 5)]
        public string Street { get; set; }

        [Display(Name="House Number")]
        public int? HouseNumber { get; set; }

        [Display(Name = "Company Of Work")]
        [StringLength(30, MinimumLength = 5)]
        public string CompanyOfWork { get; set; }
        
        public int? Age { get; set; }
    }
}