using System.Data.Entity.ModelConfiguration;
using ORM.Entities;

namespace ORM.ConfigurationEntities
{
    class FriendConfig : EntityTypeConfiguration<Friend>
    {
        public FriendConfig()
        {
            HasKey(p => p.Id);
        }
    }
}
