using System.Collections.Generic;

namespace Entities
{
    public class Position
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<CareerHistory> Career { get; set; }
    }
}
