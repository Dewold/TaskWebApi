using Entities;
using System.Data.Entity.ModelConfiguration;

namespace Data.DbConfiguration
{
    public class EmployeeConfig : EntityTypeConfiguration<Employee>
    {
        public EmployeeConfig()
        {
            var self = this;

            self.HasKey(pk => pk.Id);

            self.Property(fn => fn.FirstName)
                .HasColumnType("nvarchar")
                .HasMaxLength(70)
                .IsRequired();
            self.HasIndex(fn => fn.FirstName);

            self.Property(ln => ln.LastName)
               .HasColumnType("nvarchar")
               .HasMaxLength(70)
               .IsRequired();
            self.HasIndex(ln => ln.LastName);

            self.Property(s => s.Salary)
               .HasColumnType("numeric")
               .HasPrecision(8, 2)
               .IsRequired();
        }
    }
}
