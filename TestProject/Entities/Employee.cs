using System.Collections.Generic;

namespace Entities
{
    public class Employee
    {
        public Employee()
        {
            this.Career = new HashSet<CareerHistory>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Salary { get; set; }
        public int CurrentPositionId { get; set; }

        public Position CurrentPosition { get; set; }
        public virtual ICollection<CareerHistory> Career { get; set; }
    }
}
