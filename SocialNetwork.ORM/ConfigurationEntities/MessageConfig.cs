using System.Data.Entity.ModelConfiguration;
using ORM.Entities;

namespace ORM.ConfigurationEntities
{
    public class MessageConfig : EntityTypeConfiguration<Message>
    {
        public MessageConfig()
        {
            HasKey(p => p.Id);

            Property(p => p.TextMessage)
                .IsRequired()
                .HasMaxLength(500);

            Property(p => p.DateTimeMessage)
                .IsRequired()
                .HasColumnType("datetime");
        }
    }
}
