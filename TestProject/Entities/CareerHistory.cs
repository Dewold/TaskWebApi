using System;

namespace Entities
{
    public class CareerHistory
    {
        public int Id { get; set; }
        public DateTime HireDate { get; set; }
        public DateTime? DismissalDate { get; set; }
        public int EmployeeId { get; set; }
        public int PositionId { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Position Position { get; set; }
    }
}
