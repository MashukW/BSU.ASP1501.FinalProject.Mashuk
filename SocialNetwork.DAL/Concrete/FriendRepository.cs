using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using DAL.Interface.DTO;
using DAL.Interface.Repository;
using ORM.Entities;
using static SocialNetwork.Helper.HelperConvert;

namespace DAL.Concrete
{
    public class FriendRepository : IFriendRepository
    {
        private readonly DbContext context;

        public FriendRepository(DbContext context)
        {
            if (context == null)
                throw new NullReferenceException(nameof(context));
            this.context = context;
        }

        #region Implementation of interface methods --> IFriendRepository

        public IEnumerable<UserDTO> GetFriends(int userId)
        {
            if (userId < 0)
                return null;

            IEnumerable<Friend> friends = context.Set<Friend>().
                Include("FriendUser").
                Where(p => p.UserId == userId);

            return from friend in friends
                   where friend.FriendUser != null
                   select EntityConvert<User, UserDTO>(friend.FriendUser);
        }
        
        public bool RemoveFriend(int userId, int friendToRemoveId)
        {
            if (userId < 0 || friendToRemoveId < 0)
                return false;
            
            Friend friendToRemove = context.Set<Friend>().FirstOrDefault(
                p => p.UserId == userId && p.FriendUserId == friendToRemoveId);

            if (friendToRemove == null)
                return false;
           
            context.Set<Friend>().Remove(friendToRemove);
            return true;
        }

        public bool AddFriend(int userId, int friendToAddId)
        {
            if (userId < 0 || friendToAddId < 0)
                return false;
            
            // При добавлении неправильного Id друга
            // возникает исключение ==> DbUpdateExceptio
            context.Set<Friend>().Add(new Friend()
            {
                UserId = userId,
                FriendUserId = friendToAddId,
                Confirmed = false
            });

            return true;
        }

        public IEnumerable<FriendDTO> FindBy(Expression<Func<FriendDTO, bool>> predicate)
        {
            if (predicate == null)
                return null;

            var friends = context.Set<Friend>().Where(PredicateConvert<FriendDTO, Friend>(predicate));
            
            return EntityConvert<Friend, FriendDTO>(friends);
        }

        public IQueryable<FriendDTO> GetAll()
        {
            return context.Set<Friend>().Select(GetConverter());
        }
        
        public FriendDTO GetById(int id)
        {
            if (id < 0)
                return null;
            
            return EntityConvert<Friend, FriendDTO>(context.Set<Friend>().Find(id));
        }
        
        public void ToConfirm(int userId, int anyoneСonfirmId)
        {
            if (userId < 0 || anyoneСonfirmId < 0)
                return;

            var friendToConfirm = context.Set<Friend>().FirstOrDefault(p => p.UserId == userId && p.FriendUserId == anyoneСonfirmId);

            if (friendToConfirm == null)
                return;

            friendToConfirm.Confirmed = true;
            context.Set<Friend>().AddOrUpdate(friendToConfirm);
        }

        #endregion

        private Expression<Func<Friend, FriendDTO>> GetConverter()
        {
            return p => new FriendDTO()
            {
                Id = p.Id,
                UserId = p.UserId,
                FriendUserId =p.FriendUserId,
                Confirmed = p.Confirmed
            };
        } 
    }
}
