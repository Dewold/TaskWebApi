using Entities;
using System.Data.Entity.ModelConfiguration;

namespace Data.DbConfiguration
{
    public class PositionConfig : EntityTypeConfiguration<Position>
    {
        public PositionConfig()
        {
            var self = this;

            self.HasKey(pk => pk.Id);

            self.Property(n => n.Name)
                .HasColumnType("nvarchar")
                .HasMaxLength(150)
                .IsRequired();
            self.HasIndex(n => n.Name).IsUnique();
        }
    }
}
