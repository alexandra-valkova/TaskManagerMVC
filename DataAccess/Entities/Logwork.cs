using System;

namespace DataAccess.Entities
{
    public class Logwork : BaseEntity
    {
        public int WorkingHours { get; set; }

        public DateTime CreateDate { get; set; }

        public int TaskID { get; set; }

        public int UserID { get; set; }

        public virtual Task Task { get; set; }

        public virtual User User { get; set; }
    }
}