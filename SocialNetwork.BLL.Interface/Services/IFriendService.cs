using System.Collections.Generic;
using BLL.Interface.Entities;

namespace BLL.Interface.Services
{
    public interface IFriendService
    {
        bool Add(int userId, int friendToAddId);
        IEnumerable<UserBLL> GetAllFriends(int userId);
        IEnumerable<FriendBLL> GetAllFriendsSentRequest(int userId);
        FriendBLL GetById(int id);
        bool Remove(int userId, int deleteUserId);
        void ToConfirm(int userId, int anyoneСonfirmId);
    }
}
