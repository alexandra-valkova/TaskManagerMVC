using DataAccess.Entities;
using System.Data.Entity;

namespace DataAccess
{
    class TaskManagerMvcDB<T> : DbContext where T : BaseEntity
    {
        public TaskManagerMvcDB() : base("name=TaskManagerMvcDB")
        {

        }

        public DbSet<T> Items { get; set; }        
    }
}
