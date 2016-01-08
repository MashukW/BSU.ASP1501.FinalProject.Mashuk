using System;
using System.Collections.Generic;
using BLL.Interface.Entities;
using BLL.Interface.Services;
using DAL.Interface.Repository;

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
        
        public bool Add(FriendBLL entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<FriendBLL> GetAllFriends(int userId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<FriendBLL> GetAllFriendsSentRequest(int userId)
        {
            throw new NotImplementedException();
        }

        public FriendBLL GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Remove(FriendBLL user, FriendBLL deleteUser)
        {
            throw new NotImplementedException();
        }

        public void ToConfirm(FriendBLL fromUser, FriendBLL toUser)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
