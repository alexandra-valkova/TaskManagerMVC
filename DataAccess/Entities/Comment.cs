using System;

namespace DataAccess.Entities
{
    public class Comment : BaseEntity
    {
        public string Text { get; set; }

        public DateTime CreateDate { get; set; }

        public int TaskID { get; set; }

        public int UserID { get; set; }

        public virtual Task Task { get; set; }

        public virtual User User { get; set; }
    }
}