using System;

namespace DAL.Interface.DTO
{
    public class UserProfileDTO : IEntityDAL
    {
        public int Id { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string MobilePhoneNumber { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int? HouseNumber { get; set; }
        public string CompanyOfWork { get; set; }
        public int? Age
        {
            get
            {
                if (DateOfBirth == null)
                    return null;
                return DateTime.Now.Year - DateOfBirth.Value.Year;
            }
            set { }
        }
    }
}
