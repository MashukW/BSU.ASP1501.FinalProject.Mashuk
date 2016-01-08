namespace BLL.Interface.Entities
{
    public class FriendBLL : IEntityBLL
    {
        public FriendBLL()
        {

        }

        public FriendBLL(int id, int? fromUserId, int? toUserId, bool confirmed)
        {
            Id = id;
            FromUserId = fromUserId;
            ToUserId = toUserId;
            Confirmed = confirmed;
        }

        public int Id { get; set; }
        public int? FromUserId { get; set; }
        public int? ToUserId { get; set; }
        public bool Confirmed { get; set; }
    }
}
