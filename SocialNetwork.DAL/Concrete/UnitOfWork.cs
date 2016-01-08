using System;
using System.Data.Entity;
using DAL.Interface.Repository;

namespace DAL.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext context;

        public UnitOfWork(DbContext context)
        {
            if (context == null)
                throw new NullReferenceException(nameof(context));

            this.context = context;
        }
        
        #region The implementation of the interface --> IUnitOfWork

        #region Properties

        public IUserRepository UserRepository => new UserRepository(context);

        public IRoleRepository RoleRepository => new RoleRepository(context);

        public IUserProfileRepository UserProfileRepository => new UserProfileRepository(context);

        public IMessageRepository MessageRepository => new MessageRepository(context);
        
        public IFriendRepository FriendRepository => new FriendRepository(context);

        #endregion

        #region Methods

        public void Commit()
        {
            context?.SaveChanges();
        }

        public void Dispose()
        {
            context?.Dispose();
        }

        #endregion

        #endregion
    }
}
