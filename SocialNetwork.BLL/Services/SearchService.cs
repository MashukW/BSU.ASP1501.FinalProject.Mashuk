using System;
using System.Collections.Generic;
using System.Linq;
using BLL.Interface.Entities;
using DAL.Interface.DTO;
using DAL.Interface.Repository;
using SocialNetwork.BLL.Interface.Services;
using static SocialNetwork.Helper.HelperConvert;

namespace BLL.Services
{
    public class SearchService : ISearchService
    {
        private readonly IUnitOfWork workRepository;

        public SearchService(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
                throw new ArgumentNullException(nameof(unitOfWork));

            workRepository = unitOfWork;
        }

        public IEnumerable<UserBLL> Search(string criterion)
        {
            if (criterion == null)
                return null;

            DateTime criterionDateTime;

            if (DateTime.TryParse(criterion, out criterionDateTime))
            {
                var userByDateOfBirthDay = workRepository.UserProfileRepository
                    .GetAllUsersBy(p => p.DateOfBirth == criterionDateTime);

                var userByCreationDate =
                    workRepository.UserRepository
                        .GetAll()
                        .Where(p => p.CreationDate == criterionDateTime);

                return EntityConvert<UserDTO, UserBLL>(userByDateOfBirthDay.Union(userByCreationDate));
            }

            try
            {
                int criterionInt = int.Parse(criterion);
                return SearchBy(criterionInt);
            }
            catch (FormatException)
            {
                 return SearchBy(criterion);
            }
        }

        private IEnumerable<UserBLL> SearchBy(int criterion)
        {
            var result = new List<IEnumerable<UserDTO>>
            {
                // var userByHouse = 
                workRepository.UserProfileRepository
                    .GetAllUsersBy(p => p.HouseNumber == criterion),

                // userByAge
                workRepository.UserProfileRepository
                    .GetAllUsersBy(p => p.Age == criterion)
            };

            return GetResultSearch(result);
        }

        private IEnumerable<UserBLL> SearchBy(string criterion)
        {
            var result = new List<IEnumerable<UserDTO>>
            {
                // userByFirstName
                workRepository.UserRepository
                    .GetAll()
                    .Where(p => p.FirstName == criterion),

                // userByEmail
                workRepository.UserRepository
                    .GetAll()
                    .Where(p => p.Email == criterion),

                // userByMiddleName
                workRepository.UserProfileRepository
                    .GetAllUsersBy(p => p.MiddleName == criterion),

                // userByLastName
                workRepository.UserProfileRepository
                    .GetAllUsersBy(p => p.LastName == criterion),

                // userByGender
                workRepository.UserProfileRepository
                    .GetAllUsersBy(p => p.Gender == criterion),

                // userByMobilePhoneNumber
                workRepository.UserProfileRepository
                    .GetAllUsersBy(p => p.MobilePhoneNumber == criterion),

                // userByCountry
                workRepository.UserProfileRepository
                    .GetAllUsersBy(p => p.Country == criterion),

                // userByCity
                workRepository.UserProfileRepository
                    .GetAllUsersBy(p => p.City == criterion),

                // userByStreet
                workRepository.UserProfileRepository
                    .GetAllUsersBy(p => p.Street == criterion),

                // userByCompanyOfWork
                workRepository.UserProfileRepository
                    .GetAllUsersBy(p => p.CompanyOfWork == criterion),
            };
            
            return GetResultSearch(result);
        }

        private IEnumerable<UserBLL> GetResultSearch(List<IEnumerable<UserDTO>> users)
        {
            if (users == null)
                return null;

            IEnumerable<UserDTO> result = new List<UserDTO>();

            for (int i = 0; i < users.Count; i++)
                if (users[i] != null && users[i].Count() > 0)
                    result = result.Union(users[i]);

            return EntityConvert<UserDTO, UserBLL>(result);
        }
    }
}
