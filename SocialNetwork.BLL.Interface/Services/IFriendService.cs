using System.Collections.Generic;
using BLL.Interface.Entities;

namespace BLL.Interface.Services
{
    public interface IFriendService
    {
        bool Add(FriendBLL entity);
        IEnumerable<FriendBLL> GetAllFriends(int userId);
        IEnumerable<FriendBLL> GetAllFriendsSentRequest(int userId);
        FriendBLL GetById(int id);
        bool Remove(FriendBLL user, FriendBLL deleteUser);
        void ToConfirm(FriendBLL fromUser, FriendBLL toUser);
    }
}
