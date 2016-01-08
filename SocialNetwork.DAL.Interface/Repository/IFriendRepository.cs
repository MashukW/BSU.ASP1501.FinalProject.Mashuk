using System.Collections.Generic;
using DAL.Interface.DTO;
using DAL.Interface.Repository.RepositoryCollective;

namespace DAL.Interface.Repository
{
    public interface IFriendRepository : IRepositoryGetById<FriendDTO>, IRepositoryFindBy<FriendDTO>,
        IRepositoryGetAll<FriendDTO>
    {
        IEnumerable<UserDTO> GetFriends(int userId);
        bool RemoveFriend(int userId, int friendToRemoveId);
        bool AddFriend(int userId, int friendToAddId);
        void ToConfirm(int friendToConfirmId);
    }
}
