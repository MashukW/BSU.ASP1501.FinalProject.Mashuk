using System;

namespace DAL.Interface.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository UserRepository { get; }
        IRoleRepository RoleRepository { get; }
        IUserProfileRepository UserProfileRepository { get; }
        IMessageRepository MessageRepository { get; }
        IFriendRepository FriendRepository { get; }

        void Commit();
    }
}
