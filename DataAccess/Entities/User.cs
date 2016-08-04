using System.Collections.Generic;

namespace DataAccess.Entities
{
    public class User : BaseEntity
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public bool IsAdmin { get; set; }

        public virtual List<Logwork> Logworks { get; set; }

        public virtual List<Comment> Comments { get; set; }

        public virtual string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
    }
}