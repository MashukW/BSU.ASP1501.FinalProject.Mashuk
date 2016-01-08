using System.Data.Entity.ModelConfiguration;
using ORM.Entities;

namespace ORM.ConfigurationEntities
{
    class RoleConfig : EntityTypeConfiguration<Role>
    {
        public RoleConfig()
        {
            HasKey(p => p.Id);
            Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(20);
        }
    }
}
