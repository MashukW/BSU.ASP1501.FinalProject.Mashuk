using System.Data.Entity;
using ORM.ConfigurationEntities;
using ORM.Entities;

namespace ORM.EF
{
    public class SocialNetworkContext : DbContext
    {
        public SocialNetworkContext()
            : base("name=SocialNetwork")
        {
            
        }
        
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Role> Roles { get; set; } 
        public virtual DbSet<UserProfile> UserProfiles { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<Friend> Friends { get; set; } 
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserConfig());
            modelBuilder.Configurations.Add(new RoleConfig());
            modelBuilder.Configurations.Add(new UserProfileConfig());
            modelBuilder.Configurations.Add(new MessageConfig());
            modelBuilder.Configurations.Add(new FriendConfig());

            base.OnModelCreating(modelBuilder);
        }
    }
}
