using System;
using System.Collections.Generic;
using System.Linq;
using BLL.Interface.Entities;
using BLL.Interface.Services;
using DAL.Interface.DTO;
using DAL.Interface.Repository;
using static SocialNetwork.Helper.HelperConvert;

namespace BLL.Services
{
    public class FriendService : IFriendService
    {
        private readonly IUnitOfWork workRepository;

        public FriendService(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
                throw new ArgumentNullException(nameof(unitOfWork));

            workRepository = unitOfWork;
        }

        #region Implementation of interface methods --> IFriendService
        
        public bool Add(int userId, int friendToAddId)
        {
            if (userId < 0 || friendToAddId < 0)
                return false;

            bool success = workRepository.FriendRepository.AddFriend(userId, friendToAddId);

            if (!success)
                return false;

            workRepository.Commit();
            return true;
        }

        public IEnumerable<UserBLL> GetAllFriends(int userId)
        {
            if (userId < 0)
                return null;

            var friends = workRepository.FriendRepository.GetFriends(userId);

            return EntityConvert<UserDTO, UserBLL>(friends);
        }

        public IEnumerable<FriendBLL> GetAllFriendsSentRequest(int userId)
        {
            if (userId < 0)
                return null;

            IEnumerable<FriendBLL> friends = EntityConvert<FriendDTO, FriendBLL>(workRepository.FriendRepository.GetAll());
            
            return friends.Where(p => p.UserId == userId).Where(p=>p.Confirmed == false);
        }

        public FriendBLL GetById(int id)
        {
            return id < 0 ? null : EntityConvert<FriendDTO, FriendBLL>(workRepository.FriendRepository.GetById(id));
        }

        public bool Remove(int userId, int deleteUserId)
        {
            if (userId < 0 || deleteUserId < 0)
                return false;

            var success = workRepository.FriendRepository.RemoveFriend(userId, deleteUserId);

            if (!success)
                return false;

            workRepository.Commit();
            return true;
        }

        public void ToConfirm(int userId, int anyoneСonfirmId)
        {
            if (userId < 0 || anyoneСonfirmId < 0)
                return;

            workRepository.FriendRepository.ToConfirm(userId, anyoneСonfirmId);
            workRepository.Commit();
        }

        #endregion
    }
}
