using Entities;
using Data.DbConfiguration;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;

namespace Data
{
    public class EmployeeManagementContext : DbContext
    {
        private EntityTypeConfiguration<Employee> employeeConfig;
        private EntityTypeConfiguration<Position> positionConfig;
        private EntityTypeConfiguration<CareerHistory> careerHistoryConfig;

        public EmployeeManagementContext()
            // connection name from App.config file
            : base("Name=DbConnection")
        {
            employeeConfig = new EmployeeConfig();
            positionConfig = new PositionConfig();
            careerHistoryConfig = new CareerHistoryConfig();
        }

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
        public virtual DbSet<CareerHistory> Careers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(employeeConfig);
            modelBuilder.Configurations.Add(positionConfig);
            modelBuilder.Configurations.Add(careerHistoryConfig);
        }
    }
}
