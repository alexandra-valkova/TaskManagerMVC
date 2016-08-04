using DataAccess.Entities;
using System.Data.Entity;

namespace TaskManagerMVC
{
    public class AppContext : DbContext
    {
        public AppContext() : base("name=TaskManagerMvcDB")
        {

        }

        public DbSet<User> Users { get; set; }

        public DbSet<Task> Tasks { get; set; }

        public DbSet<Logwork> Logworks { get; set; }

        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Task>().HasRequired(m => m.Creator).WithMany().HasForeignKey(m => m.CreatorID).WillCascadeOnDelete(false);
            modelBuilder.Entity<Task>().HasRequired(m => m.Responsible).WithMany().HasForeignKey(m => m.ResponsibleID).WillCascadeOnDelete(false);
        }
    }
}