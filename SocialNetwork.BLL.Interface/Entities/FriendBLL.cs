namespace BLL.Interface.Entities
{
    public class FriendBLL : IEntityBLL
    {
        public FriendBLL()
        {

        }

        public FriendBLL(int id, int? friendUserId, int? userId, bool confirmed)
        {
            Id = id;
            UserId = userId;
            FriendUserId = friendUserId;
            Confirmed = confirmed;
        }

        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? FriendUserId { get; set; }
        public bool Confirmed { get; set; }
    }
}
