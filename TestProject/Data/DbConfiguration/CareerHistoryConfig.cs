using Entities;
using System.Data.Entity.ModelConfiguration;

namespace Data.DbConfiguration
{
    public class CareerHistoryConfig : EntityTypeConfiguration<CareerHistory>
    {
        public CareerHistoryConfig()
        {
            var self = this;

            self.HasKey(pk => pk.Id);

            self.Property(hd => hd.HireDate)
               .HasColumnType("date")
               .IsRequired();
            self.HasIndex(hd => hd.HireDate);

            self.Property(hd => hd.DismissalDate)
               .HasColumnType("date")
               .IsOptional();
            self.HasIndex(dd => dd.DismissalDate);

            self.HasRequired(ps => ps.Position)
                .WithMany(c => c.Career)
                .HasForeignKey(p => p.PositionId)
                .WillCascadeOnDelete(false);

            self.HasRequired(em => em.Employee)
                .WithMany(c => c.Career)
                .HasForeignKey(e => e.EmployeeId)
                .WillCascadeOnDelete(false);
        }
    }
}
