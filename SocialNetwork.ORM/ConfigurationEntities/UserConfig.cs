using System.Data.Entity.ModelConfiguration;
using ORM.Entities;

namespace ORM.ConfigurationEntities
{
    class UserConfig : EntityTypeConfiguration<User>
    {
        public UserConfig()
        {
            HasKey(p => p.Id);

            HasMany(p => p.Friends)
                .WithRequired(r => r.User)
                .HasForeignKey(k => k.UserId);
            
            HasMany(p => p.Messages)
                .WithRequired(r => r.FromUser)
                .HasForeignKey(k => k.FromUserId);
            
            Property(p => p.FirstName)
                .IsRequired()
                .HasMaxLength(30);

            Property(p => p.CreationDate)
                .IsRequired();

            Property(p => p.Email)
                .IsRequired()
                .HasMaxLength(30);
            
            Property(p => p.Password)
                .IsRequired()
                .HasMaxLength(70);
        }
    }
}
