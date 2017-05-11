using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Repositories
{
    public abstract class BaseRepository<T> where T : BaseEntity
    {
        private TaskManagerMvcDB<T> Context { get; set; }
        public DbSet<T> DbSet { get; set; }

        public BaseRepository()
        {
            Context = new TaskManagerMvcDB<T>();
            DbSet = Context.Set<T>();
        }

        // Get All
        public List<T> GetAll(Expression<Func<T, bool>> filter = null)
        {
            DbSet<T> result = DbSet;

            if (filter != null)
            {
                return result.Where(filter).ToList();
            }

            else
            {
                return result.ToList();
            }
        }

        // Get First
        public T GetFirst(Expression<Func<T, bool>> filter = null)
        {
            DbSet<T> result = DbSet;

            if (filter != null)
            {
                return result.Where(filter).FirstOrDefault();
            }

            else
            {
                return null;
            }
        }

        // Get By ID
        public T GetByID(int id)
        {
            return DbSet.Find(id);
        }

        // Save
        public void Save(T entity)
        {
            if (entity.ID > 0)
            {
                Update(entity);
            }

            else
            {
                Insert(entity);
            }
        }

        // Add
        private void Insert(T entity)
        {
            DbSet.Add(entity);
            Context.SaveChanges();
        }

        // Edit
        private void Update(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            Context.SaveChanges();
        }

        // Delete
        public void Delete(T entity)
        {
            Context.Entry(entity).State = EntityState.Deleted;
            //DbSet.Remove(entity);
            Context.SaveChanges();
        }
    }
}